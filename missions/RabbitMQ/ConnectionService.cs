using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;

namespace missions.RabbitMQ
{
    public class ConnectionService
    {
        private string _hostName = "rabbitmq";
        private string _userName = "missions";
        private string _password = "missions";
        private string _port = "5672";
        ConnectionFactory connectionFactory = new ConnectionFactory();

        public IConnection GetRabbitMqConnection()
        {
            connectionFactory.HostName = _hostName;
            connectionFactory.UserName = _userName;
            connectionFactory.Password = _password;
            connectionFactory.Port = int.Parse(_port);

            return connectionFactory.CreateConnection();
        }
    }
}
