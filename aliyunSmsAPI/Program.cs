﻿using System;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

namespace aliyunSmsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "<accessKeyId>", "<secret>");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP


            // 随机生成6位验证码
            var rd = new Random();
            var code = new
            {
                code=rd.Next(100000,999999)
            };


            request.AddQueryParameters("PhoneNumbers", "18173608896");
            request.AddQueryParameters("SignName", "jonty博客");
            request.AddQueryParameters("TemplateCode", "SMS_197465032");

            // 验证码参数，code 转json格式
            request.AddBodyParameters("TemplateParam",code.ToJson());
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
