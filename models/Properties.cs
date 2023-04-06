namespace Roguelike.Json {

    class Properties {
        public HeroDefaultStats heroDefaultStats { get; set; } = null!;
        public EnemyDefaultStats enemyDefaultStats { get; set; } = null!;
        public EnemyGenerationParams enemyGenerationParams { get; set; } = null!;
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

    class EnemyGenerationParams {
        public int maxEnemies { get; set; }
        public int distanceBetweenEnemies { get; set; }
    }

    class Icons {
        public string hero { get; set; } = null!;
        public string item { get; set; } = null!;
        public string Forgetful { get; set; } = null!;
        public string Tracker { get; set; } = null!;
    }

    class EnemyDefaultStats {
        public EnemyStats Forgetful { get; set; } = null!;
        public EnemyStats Tracker { get; set; } = null!;
    }

    class EnemyStats {
        public string name { get; set; } = null!;
        public int hp { get; set; }
        public int armor { get; set; }
        public int maxAttack { get; set; }
        public int minAttack { get; set; }
    }
}
