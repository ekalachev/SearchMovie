using SearchMovie.Model.ResultModel;

namespace SearchMovie.UI.Wrapper
{
    public class MovieShortWrapper : ModelWrapper<MovieShort>
    {
        public MovieShortWrapper(MovieShort model) : base(model)
        {
        }

        public string Id => GetValue<string>(nameof(Model.ImdbID));

        public string Title => GetValue<string>(nameof(Model.Title));

        public string Type => GetValue<string>(nameof(Model.Type));

        public string Poster => GetValue<string>(nameof(Model.Poster));

        public string Year => GetValue<string>(nameof(Model.Year));
    }
}
