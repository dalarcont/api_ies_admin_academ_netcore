namespace IES_ADMIN_ACADEM_API.Entities
{
    public class IES_EmailModel
    {
        private string senderName;
        private string senderMail;
        private string destination;
        private string subject;
        private string body;
        private bool   isHtml;

        public IES_EmailModel(string senderName, string senderMail, string destination, string subject, string body, bool isHtml)
        {
            Destination = destination;
            Subject     = subject;
            Body        = body;
            IsHtml      = isHtml;
            SenderName  = senderName;
            SenderMail  = senderMail;
        }

        public string Destination { get => destination; set => destination = value; }
        public string Subject     { get => subject;     set => subject     = value; }
        public string Body        { get => body;        set => body        = value; }
        public bool   IsHtml      { get => isHtml;      set => isHtml      = value; }
        public string SenderName  { get => senderName;  set => senderName  = value; }
        public string SenderMail  { get => senderMail;  set => senderMail  = value; }
    }
}
