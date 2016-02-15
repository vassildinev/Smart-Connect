namespace SmartConnect.Data.Helpers.SeedProviders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;

    public class DealRequestsSeedProvider : ISeedProvider<DealRequest>
    {
        private Random random = new Random();

        private IEnumerable<string> dealRequestsComments = new List<string>()
        {
            "The guitar harms the surface around an expert solicitor." ,
            "When can the civilian moan?" ,
            "An enlightened rear bucks outside the exploited disgust." ,
            "An image smokes with a success." ,
            "Beneath the pun succeeds the nick." ,
            "The assistance rots the thousand sister." ,
            "The stirred swallow eyes the seed." ,
            "A subsidiary accents the musician." ,
            "The cooked edge pilots the fortunate chase." ,
            "A picture contrives the freeze against the entertained pant." ,
            "A tops glow rules inside the confined garbage." ,
            "A perceived consequence marks a corpse into the optical abstract." ,
            "A staircase leans against your alien craft over the committee." ,
            "Beside the chosen crossroad cooperates the blown romantic." ,
            "How can the expressed flavor stroke the cured analyst?" ,
            "When can the wasteful lunatic bubble?" ,
            "A ghost returns." ,
            "Into the wizard rattles whatever violence." ,
            "Against the photocopy swallows a faith." ,
            "An improbable bugger cooperates." ,
            "The several explosive pencils the chief beside a made mechanic." ,
            "The male liberal dislikes her negotiable slice." ,
            "The wrong mates an apparatus." ,
            "A plant laughs near a mimic electron." ,
            "A carriage steams under each received digest." ,
            "The freeway exits underneath a damp." ,
            "The related mathematician sprays a mill." ,
            "Around the chord fusses a linguistic energy." ,
            "Why does a solo referendum dash?" ,
            "The usual phenomenon divines the badge into a tops sneak." ,
            "A spoken paragraph declines outside the ribbon." ,
            "Every catalog bucks into the automobile." ,
        };

        public IEnumerable<DealRequest> GetSeedData()
        {
            int randomTake = random.Next(1, 4);
            DealRequest confirmedDealRequest = this.dealRequestsComments
                .OrderBy(dr => Guid.NewGuid())
                .Take(1)
                .Select(x => new DealRequest()
                {
                    Comment = x,
                    IsConfirmed = true
                })
                .FirstOrDefault();

            var randomRequests = this.dealRequestsComments
                .OrderBy(dr => Guid.NewGuid())
                .Take(randomTake)
                .Select(x => new DealRequest()
                {
                    Comment = x
                })
                .ToList();
            
            randomRequests.Add(confirmedDealRequest);

            return randomRequests;
        }
    }
}
