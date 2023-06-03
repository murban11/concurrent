using System.Collections.Concurrent;
using System.Numerics;
using System.Xml;

namespace Data
{
    internal class Logger
    {
        private readonly int BoardHeight;
        private readonly int BoardWidth;
        private BlockingCollection<BallData> queue;
        private Task task;
        private string logFilepath = "../../../../../Data/log.xml";
        private XmlWriter writer;

        public Logger(int height, int width) 
        {
            BoardHeight = height;
            BoardWidth = width;
            queue = new BlockingCollection<BallData>();
            //task = Task.Run(startLogging);
        }

        public void appendToQueue(IBall ball)
        {
            if (ball == null)
            {
                return;
            }

            if (!queue.IsAddingCompleted)
            {
                if(ball.IsRunning)
                {
                    queue.Add(new BallData(ball.ID, ball.Coordinates, DateTime.Now));
                }
            }

        }

        public void startLogging()
        {
            task = Task.Run(() =>
            {
                using (writer = XmlWriter.Create(logFilepath, new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true
                }))
                {
                    writer.WriteStartElement("Log");
                    foreach (BallData ball in queue.GetConsumingEnumerable())
                    {
                        writer.WriteStartElement("Ball");
                        writer.WriteElementString("ID", XmlConvert.ToString(ball.ID));
                        writer.WriteElementString("X", XmlConvert.ToString(ball.X));
                        writer.WriteElementString("Y", XmlConvert.ToString(ball.Y));
                        writer.WriteElementString("Time", ball.Time);
                        writer.WriteEndElement();
                    }
                }
            });
            
        }

        internal class BallData
        {
            public int ID { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public string Time { get; set; }

            public BallData(int id, Vector2 currentPosition, DateTime time)
            {
                ID = id;
                X = currentPosition.X;
                Y = currentPosition.Y;
                Time = time.ToString("HH:mm:ss:ffff");
            }
        }
    }
}
