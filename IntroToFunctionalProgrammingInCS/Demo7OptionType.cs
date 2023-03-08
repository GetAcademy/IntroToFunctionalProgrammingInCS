using System.Reflection;

namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo7OptionType
    {
        public static void Run()
        {

        }

        public static Leaderboard GetLeaderboardV1(
            IPositionFinder positionFinder,
            IPlaceLookup placeLookup,
            ILeaderboardRepository leaderboardRepository
            )
        {
            var position = positionFinder.Get();
            var place = placeLookup.Lookup(position);
            var leaderboard = leaderboardRepository.GetByPlace(place);
            return leaderboard;
        }

        public static Leaderboard GetLeaderboardV2(
            IPositionFinder positionFinder,
            IPlaceLookup placeLookup,
            ILeaderboardRepository leaderboardRepository)
        {
            var position = positionFinder.Get();
            if (position == null) return null;
            var place = placeLookup.Lookup(position);
            if (place == null) return null;
            var leaderboard = leaderboardRepository.GetByPlace(place);
            return leaderboard;
        }

        public static Leaderboard GetLeaderboardV3(
            IPositionFinder positionFinder,
            IPlaceLookup placeLookup,
            ILeaderboardRepository leaderboardRepository)
        {
            // https://dev.to/ntreu14/let-s-implement-an-option-type-in-c-1ibn
            return Wrap(positionFinder.Get())
                .Wrap()
            var place = placeLookup.Lookup(position);
            if (place == null) return null;
            var leaderboard = leaderboardRepository.GetByPlace(place);
            return leaderboard;
        }

        static IOption<T> Wrap<T>(T value)
        {
            return value == null ? new None<T>() : new Some<T>(value);
        }
    }

    interface IPositionFinder
    {
        Position Get();
    }

    interface IPlaceLookup
    {
        Place Lookup(Position position);
    }

    interface ILeaderboardRepository
    {
        Leaderboard GetByPlace(Place place);
    }



    class Leaderboard{}
    public class Position
    {
        public double Latitude { get;  }
        public double Longitude { get; }

        public Position(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    public class Place
    {
        public string Country { get; }
        public string Region { get; }
        public string City { get; }

        public Place(string country, string region, string city)
        {
            Country = country;
            Region = region;
            City = city;
        }
    }
}
