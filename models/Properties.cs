namespace Roguelike.Json {

    class Properties {
        public HeroDefaultStats heroDefaultStats { get; set; } = null!;
        public Icons icons { get; set; } = null!;
        public List<Map> maps { get; set; } = null!;
        public List<string> forbidenSymbols { get; set; } = null!;
    }

    class HeroDefaultStats {
        public int defaultHP { get; set; }
        public int defaultDefence { get; set; }
        public int defaultMinAttack { get; set; }
        public int defaultMaxAttack { get; set; }
    }

    class Icons {
        public string hero { get; set; } = null!;
        public string item { get; set; } = null!;
        public string Forgetful { get; set; } = null!;
        public string Tracker { get; set; } = null!;
    }
}
