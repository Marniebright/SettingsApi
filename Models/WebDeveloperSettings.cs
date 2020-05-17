namespace Models {
    public class WebDeveloperSettings {

        private int _id;
        private string _type;
        private string _platform;

        public WebDeveloperSettings(Settings settings)
        {
            this._id = settings.Id;
            this._type = settings.Type;
            this._platform = settings.Platform;
        }
    }
}