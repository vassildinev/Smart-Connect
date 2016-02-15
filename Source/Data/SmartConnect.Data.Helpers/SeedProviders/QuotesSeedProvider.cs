namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System.Collections.Generic;

    using Contracts;
    using Models;

    public class QuotesSeedProvider : ISeedProvider<Quote>
    {
        public IEnumerable<Quote> GetSeedData()
        {
            return new List<Quote>()
            {
                new Quote()
                {
                    Author = "Colin Powell",
                    Content = "There are no secrets to success. It is the result of preparation, hard work, and learning from failure."
                },
                new Quote()
                {
                    Author = "Mark Twain",
                    Content = "Whenever you find yourself on the side of the majority, it is time to pause and reflect."
                },
                new Quote()
                {
                    Author = "Theodore Isaac Rubin",
                    Content = "Happiness does not come from doing easy work but from the afterglow of satisfaction that comes after the achievement of a difficult task that demanded our best."
                },
                new Quote()
                {
                    Author = "Jack Welch",
                    Content = "An organization's ability to learn, and translate that learning into action rapidly, is the ultimate competitive advantage."
                },
                new Quote()
                {
                    Author = "Steve Jobs",
                    Content = "I want to put a ding in the universe."
                },
                new Quote()
                {
                    Author = "Steve Jobs",
                    Content = "Sometimes when you innovate, you make mistakes. It is best to admit them quickly, and get on with improving your other innovations."
                },
                new Quote()
                {
                    Author = "Aristotle Onassis",
                    Content = "The secret of business is to know something that nobody else knows."
                },
                new Quote()
                {
                    Author = "Tom Peters",
                    Content = "Almost all quality improvement comes via simplification of design, manufacturing... layout, processes, and procedures."
                },
                new Quote()
                {
                    Author = "W. Clement Stone",
                    Content = "Sales are contingent upon the attitude of the salesman - not the attitude of the prospect."
                },
                new Quote()
                {
                    Author = "Winston Churchill",
                    Content = "Some people regard private enterprise as a predatory tiger to be shot. Others look on it as a cow they can milk. Not enough people see it as a healthy horse, pulling a sturdy wagon."
                },
                new Quote()
                {
                    Author = "Herbert Hoover",
                    Content = "Economic depression cannot be cured by legislative action or executive pronouncement. Economic wounds must be healed by the action of the cells of the economic body - the producers and consumers themselves."
                },
                new Quote()
                {
                    Author = "Sam Walton",
                    Content = "We're all working together; that's the secret."
                },
                new Quote() {
                    Author = "Harold S. Geneen",
                    Content = "In the business world, everyone is paid in two coins: cash and experience. Take the experience first; the cash will come later."
                },
                new Quote()
                {
                    Author = "Henry Ford",
                    Content = "A business that makes nothing but money is a poor business."
                },
                new Quote()
                {
                    Author = "Thomas A. Edison",
                    Content = "Just because something doesn't do what you planned it to do doesn't mean it's useless."
                },
                new Quote()
                {
                    Author = "Dale Carnegie",
                    Content = "Most of the important things in the world have been accomplished by people who have kept on trying when there seemed to be no hope at all."
                },
                new Quote()
                {
                    Author = "Mary Kay Ash",
                    Content = "People are definitely a company's greatest asset. It doesn't make any difference whether the product is cars or cosmetics. A company is only as good as the people it keeps."
                },
                new Quote()
                {
                    Author = "Thomas Jefferson",
                    Content = "I hope we shall crush in its birth the aristocracy of our monied corporations which dare already to challenge our government to a trial by strength, and bid defiance to the laws of our country."
                },
                new Quote()
                {
                    Author = "Richard Nelson Bolles",
                    Content = "Not for nothing is their motto TGIF - 'Thank God It's Friday.' They live for the weekends, when they can go do what they really want to do."
                },
                new Quote()
                {
                    Author = "Adam Smith",
                    Content = "It is not from the benevolence of the butcher, the brewer, or the baker that we expect our dinner, but from their regard to their own interest."
                },
                new Quote()
                {
                    Author = "Jack Welch",
                    Content = "Willingness to change is a strength, even if it means plunging part of the company into total confusion for a while."
                },
                new Quote()
                {
                    Author = "B. C. Forbes",
                    Content = "If you don't drive your business, you will be driven out of business."
                },
                new Quote()
                {
                    Author = "Lucius Annaeus Seneca",
                    Content = "If one does not know to which port one is sailing, no wind is favorable."
                },
                new Quote()
                {
                    Author = "Gary Ryan Blair",
                    Content = "Do more than is required. What is the distance between someone who achieves their goals consistently and those who spend their lives and careers merely following? The extra mile."
                },
                new Quote()
                {
                    Author = "Elon Musk",
                    Content = "Great companies are built on great products."
                },
                new Quote()
                {
                    Author = "Peter Drucker",
                    Content = "Rank does not confer privilege or give power. It imposes responsibility."
                },
                new Quote()
                {
                    Author = "Napoleon Hill",
                    Content = "The majority of men meet with failure because of their lack of persistence in creating new plans to take the place of those which fail."
                },
                new Quote()
                {
                    Author = "Peter Drucker",
                    Content = "Time is the scarcest resource and unless it is managed nothing else can be managed."
                },
                new Quote()
                {
                    Author = "Arnold H. Glasow",
                    Content = "One of the tests of leadership is the ability to recognize a problem before it becomes an emergency."
                },
                new Quote()
                {
                    Author = "Ted Turner",
                    Content = "My son is now an 'entrepreneur.' That's what you're called when you don't have a job."
                },
                new Quote()
                {
                    Author = "Andrew Carnegie",
                    Content = "And while the law of competition may be sometimes hard for the individual, it is best for the race, because it ensures the survival of the fittest in every department."
                },
                new Quote()
                {
                    Author = "Walt Disney",
                    Content = "Disneyland is a work of love. We didn't go into Disneyland just with the idea of making money."
                },
                new Quote()
                {
                    Author = "Peter Drucker",
                    Content = "The entrepreneur always searches for change, responds to it, and exploits it as an opportunity."
                },
                new Quote() {
                    Author = "Marie von Ebner-Eschenbach",
                    Content = "If you have one good idea, people will lend you twenty."
                },
            };
        }
    }
}
