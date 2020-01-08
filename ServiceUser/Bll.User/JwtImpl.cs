using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AngleX.SDK.User;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace Bll.User
{
    public class JwtImpl : IJwtable
    {
        IBase64UrlEncoder urlEncoder;
        IJsonSerializer serializer;
        IJwtAlgorithm algorithm;

        IJwtEncoder encoder;

        IDateTimeProvider provider ;
        IJwtValidator validator ;

        IJwtDecoder decoder;
        

        public ISecretable ISec { get; set; }

        public JwtImpl(ISecretable iSec)
        {
            this.ISec = iSec;
            init();
        }
        void init()
        {
             urlEncoder = new JwtBase64UrlEncoder();
             serializer = new JsonNetSerializer();
             algorithm = new HMACSHA256Algorithm();
             encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

             provider = new UtcDateTimeProvider();
             validator = new JwtValidator(serializer, provider);
             decoder = new JwtDecoder(serializer, validator, urlEncoder);
        }
        public TokenModel Decoding(string base64Token)
        {
            try {
                
             
                var json = decoder.Decode(base64Token, ISec.SecretCurrent, verify: true);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(json);
            }
            catch (TokenExpiredException) {
                return null;
            }
            catch (SignatureVerificationException) {
                return null;
            }
            
        }
    
        public string Encoding(AuthUser authUser)
        {                                
            TokenModel tM = new TokenModel();
            tM.create = AngleX.CommonHelper.getTimeStampSecond();
            tM.exp = tM.create + ConstR.TokenExp;
            tM.load = authUser;
            var token = encoder.Encode(tM, ISec.SecretCurrent);
            return token;
        }
    }
}
