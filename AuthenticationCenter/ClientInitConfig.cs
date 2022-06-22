using IdentityServer4.Models;

public class ClientInitConfig
{
    public static IEnumerable<IdentityResource> identityResources=>
    new IdentityResource[]{
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<Client> GetClients()
    {
        return new Client[]
        {
           new Client()
           {
               ClientId="qq",//客户端唯一标识
               ClientName="AuthCent",
               ClientSecrets=new []{new Secret("abc".Sha256())},//客户端密码
              AllowedGrantTypes=GrantTypes.ClientCredentials, //授权方式，客户端认证
               AllowedScopes=new[]{"scope1"}//允许访问的资源
               ,Claims=new List<ClientClaim>()
               {
                   new ClientClaim(IdentityModel.JwtClaimTypes.Role,"Admin"),
                   new ClientClaim(IdentityModel.JwtClaimTypes.NickName,"a"),
                   new ClientClaim("eMail","982370574@qq.com")
               }
           }
        };
    }

    public static IEnumerable<ApiScope> GetApiScopes()
    {
        return new ApiScope[]
        {
          new ApiScope("scope1"), new ApiScope("scope2"),
        };
    }

    public static IEnumerable<ApiResource> GetApiResources()
    {
        return new[] {
            new ApiResource ("UserApi", "用户获取API"){
                Scopes={"scope1"}
            }
        };
        //return new[] {
        //    new ApiResource(OAuthCofig.)
        //};
    }
}