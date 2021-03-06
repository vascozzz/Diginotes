﻿using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Client
{
    /* Client. Entity responsible for handling all the client data and respective communication with the server. */
    public class Client
    {
        // container for client data
        public ClientData data;


        // private pointers
        private IRemObj remObj;
        private Intermediate inter;
        private AppForm appForm;


        [STAThread]
        static void Main()
        {
            Client client = new Client();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(client));
        }


        /* When starting, a client should automatically connect to the server. */
        public Client()
        {
            RemotingConfiguration.Configure("Client.exe.config", false);
            inter = new Intermediate();
            inter.NewExchange += OnNewExchange;
            inter.NewQuotation += OnNewQuotation;
            
            remObj = (IRemObj)GetRemote.New(typeof(IRemObj));
            remObj.NewExchange += inter.TriggerNewExchange;
            remObj.NewQuotation += inter.TriggerNewQuotation;
        }


        public bool Register(string name, string nickname, string password)
        {
            data = remObj.Register(name, nickname, password);
            return (data != null);
        }

        /* Login, server returns null when user is not found. */
        public bool Login(string nickname, string password)
        {
            data = remObj.Login(nickname, password);
            return (data != null);
        }


        /* When disconnecting, clients should unsubscribe from server events. */
        public void Disconnect()
        {
            if (data != null)
            {
                remObj.Logout(data.name);
            }

            remObj.NewExchange -= inter.TriggerNewExchange;
            inter.NewExchange -= OnNewExchange;
        }


        /* Sets a pointer to the form where all info is displayed so that it can be updated on events' callbacks. */
        public void SetAppForm(AppForm appForm)
        {
            this.appForm = appForm;
        }


        /* Updates everything related to a client's balance and diginotes. */
        public void UpdateEconomy(ClientData clientData)
        {
            data.balance = clientData.balance;
            data.balanceAvlb = clientData.balanceAvlb;

            data.diginotes = clientData.diginotes;
            data.diginotesAvlb = clientData.diginotesAvlb;
        }


        /* Requests the server to register a new exchange (either buying or selling diginotes). */
        public void RequestExchange(ExchangeType exchangeType, int diginotes)
        {
            // Request
            UpdateData update = remObj.RequestExchange(data.user_id, exchangeType, diginotes);

            data.exchanges.Add(update.exchange);
            UpdateEconomy(update.clientData);

            // should create a new exchange and update form
            appForm.AddToHistory(update.exchange);
            appForm.UpdateEconomy();

            // if needed, ask user for a new quotation
            if (update.exchange.diginotes != update.exchange.diginotes_fulfilled)
            {
                QuotationCreator quotationCreator = new QuotationCreator(this, data.quotation, exchangeType);
                quotationCreator.Show();
            }
        }


        /* Sends a new quotation to the server. */
        public void SetQuotation(float quotation)
        {
            remObj.SetQuotation(data.user_id, quotation);
        }


        /* Asks the server to update an existing exchange. */
        public void EditExchange(ExchangeData exchange)
        {
            ClientData clientData = remObj.EditExchange(exchange);

            UpdateEconomy(clientData);
            appForm.UpdateEconomy();
        }


        /* Accepts new quotation, unblocking all unfulfilled exchanges. */
        public void UnblockExchanges()
        {
            remObj.UnblockClientExchanges(data.user_id);
        }


        /* Rejects new quotation, marking all unfulfilled exchanges as done. */
        public void RemoveExchanges()
        {
            ClientData clientData = remObj.RemoveClientExchanges(data.user_id);

            UpdateEconomy(clientData);
            appForm.UpdateEconomy();

            data.exchanges = clientData.exchanges;
            appForm.UpdateExchanges();
        }


        /* Callback triggered when the server pairs up two exchanges. */
        public void OnNewExchange(UpdateData update)
        {
            if (appForm == null || update.clientData.user_id != data.user_id) 
            {
                return;
            }

            int exchangeIndex = -1;

            // find exchange, update it with the data received
            for (int i = 0; i < data.exchanges.Count; i++) { 
                if (data.exchanges[i].exchange_id == update.exchange.exchange_id)
                {
                    data.exchanges[i].diginotes_fulfilled = update.exchange.diginotes_fulfilled;
                    exchangeIndex = i;
                    break;
                }
            }

            // update client data and its display
            UpdateEconomy(update.clientData);
            appForm.OnNewExchange(exchangeIndex);
        }  

        
        /* Callback triggered when a new quotation has been set on the server. */
        public void OnNewQuotation(int user_id, float quotation)
        {
            data.quotation = quotation;
            appForm.UpdateQuotation();

            // quotation changed, can update displayed available balance
            data.UpdateAvailabilities(data.exchanges);

            if (appForm == null || user_id == data.user_id)
            {
                return;
            }

            foreach (ExchangeData exchange in data.exchanges)
            {
                // at least one hasn't been fulfilled yet
                if (exchange.diginotes != exchange.diginotes_fulfilled)
                {
                    appForm.CreateQuotationHandler();
                    break;
                }
            }
        }
    }
}