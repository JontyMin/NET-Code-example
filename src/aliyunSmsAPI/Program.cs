using System;
using AlibabaCloud.SDK.Dysmsapi20170525;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using AlibabaCloud.OpenApiClient.Models;
using AlibabaCloud.SDK.Dysmsapi20170525.Models;
using AlibabaCloud.TeaUtil.Models;
using System.Collections.Generic;
using Tea;

namespace aliyunSmsAPI
{
    class Program
    {

        public static Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            Config config = new Config
            {
                // 必填，您的 AccessKey ID
                AccessKeyId = accessKeyId,
                // 必填，您的 AccessKey Secret
                AccessKeySecret = accessKeySecret,
            };
            // 访问的域名
            config.Endpoint = "dysmsapi.aliyuncs.com";
            return new Client(config);
        }

        static void Main(string[] args)
        {
            Client client = CreateClient("LTAI5tPD45dvn3Qg5uSHzTnE", "tDZfUrFt6yWdb6gxEQH4Y59fLwWKLa");
            SendSmsRequest sendSmsRequest = new SendSmsRequest
            {
                PhoneNumbers = "18173608896",
                SignName = "jonty博客",
                TemplateCode = "SMS_197465032",
                TemplateParam = "{\"code\":\"3333\"}",
            };
            RuntimeOptions runtime = new RuntimeOptions();
            try
            {
                // 复制代码运行请自行打印 API 的返回值
                client.SendSmsWithOptions(sendSmsRequest, runtime);
            }
            catch (TeaException error)
            {
                // 如有需要，请打印 error
                AlibabaCloud.TeaUtil.Common.AssertAsString(error.Message);
            }
            catch (Exception _error)
            {
                TeaException error = new TeaException(new Dictionary<string, object>
                {
                    { "message", _error.Message }
                });
                // 如有需要，请打印 error
                AlibabaCloud.TeaUtil.Common.AssertAsString(error.Message);
            }
        }
    }
}
