namespace ApiServer;

public static class Argument {
    public const string AspEnv = "ASPNETCORE_ENVIRONMENT";
    public const string MongoDbUri = "MongoDB_URI";
    public const string RedisUri = "Redis_URI";
    
}

public class Config {
    public IConfiguration Conf { get; }
    public string MongoDbUri { get; }
    public string RedisUri { get; }
    public string MongoDbName { get; }
    public string AspEnv { get; }
    public bool Blockade { get; private set; }


    public Config(IConfiguration conf) {
        Conf = conf;
        var aspEnv = conf.GetValue<string>(Argument.AspEnv);
        if (string.IsNullOrWhiteSpace(aspEnv)) throw new InvalidOperationException($"There isn't {Argument.AspEnv}");
        AspEnv = aspEnv;
        var mongoDbUri = conf.GetValue<string>(Argument.MongoDbUri);
        if (string.IsNullOrWhiteSpace(mongoDbUri)) throw new InvalidOperationException($"There isn't {Argument.MongoDbUri}");
        MongoDbUri = mongoDbUri;
        MongoDbName = AspEnv + "_Db"; // MongoDB에 Database 생성시 기본 DB 이름
        
        var redisUri = conf.GetValue<string>(Argument.RedisUri);
        if (string.IsNullOrWhiteSpace(redisUri)) throw new InvalidOperationException($"There isn't {Argument.RedisUri}");
        RedisUri = redisUri;
    }

    public void BlockadeOn() => Blockade = true;
    public void BlockadeOff() => Blockade = false;
}