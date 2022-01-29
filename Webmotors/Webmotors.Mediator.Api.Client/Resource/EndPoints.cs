namespace Webmotors.Mediator.Api.Client
{

    public class EndPoints
    {
        private EndPoints(string value) { Value = value; }
        public string Value { get; private set; }
        public static EndPoints Vehicles { get { return new EndPoints("/vehicles"); } }


    }
}