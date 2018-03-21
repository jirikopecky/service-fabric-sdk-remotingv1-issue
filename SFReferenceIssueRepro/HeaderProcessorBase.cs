using System;

namespace SFReferenceIssueRepro
{
    public abstract class HeaderProcessorBase
    {
        public HeaderProcessorBase NextProcessor { get; private set; }

        protected abstract void Process(ServiceRemotingMessageHeaders headers);

        public void SetNextProcessor(HeaderProcessorBase nextProcessor)
        {
            NextProcessor = nextProcessor;
        }

        public void Handle(ServiceRemotingMessageHeaders headers)
        {
            Process(headers);
            NextProcessor?.Handle(headers);
        }
    }
}
