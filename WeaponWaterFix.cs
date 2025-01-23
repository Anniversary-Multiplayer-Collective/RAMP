using System.IO;

using (var cacheStream = Cache.OpenCacheReadWrite()) 
{
    foreach (var tag in Cache.TagCache.FindAllInGroup("proj")) 
    {
        var proj = Cache.Deserialize<Projectile>(cacheStream, tag);

        proj.WaterGravityScale = proj.AirGravityScale;
        proj.WaterDamageRange = proj.AirDamageRange;

        Cache.Serialize(cacheStream, tag, proj);
    }
}