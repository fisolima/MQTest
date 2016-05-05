using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing.Impl;

namespace MQService
{
    public class MessageService
    {
        private readonly string _appName;
        private readonly Action<string, string> _messageCallback;
        private readonly Action<string> _errorCallback;

        public bool Running { get; private set; }
        public string AppName { get { return _appName;} }

        private IConnection _connection;

        public MessageService(string appName, Action<string, string> messageCallback, Action<string> errorCallback)
        {
            _appName = appName;
            _messageCallback = messageCallback;
            _errorCallback = errorCallback;
        }

        public void Start()
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = ConfigurationManager.AppSettings["RabbitMQAddress"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["RabbitMQPort"])
                };

                _connection = factory.CreateConnection();
            }
            catch (Exception exc)
            {
                _errorCallback(exc.Message);

                return;
            }

            Running = true;

            _messageCallback("<SYSTEM>", "Service started");

            //Task.Run(() =>
            //{
            //    var appNames = new [] {"WebService", "Reporter", "Logger"};
            //    var rand = new Random();

            //    for (int i = 0; i < 20; i++)
            //    {
            //        _messageCallback(appNames[rand.Next()%3], "msg: " + i);

            //        Thread.Sleep(1000 + rand.Next(500));
            //    }
            //});

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        _errorCallback("Error: " + i);

            //        Thread.Sleep(2000);
            //    }
            //});
        }

        public void Stop()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}
