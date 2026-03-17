namespace Seed.Framework.Oss
{
    public class MinioUtil
    {
        //public static IMinioClient GetClient()
        //{
        //    var minioConfig = App.GetConfig<OssConfig>(FrameworkConstant.MINIO);

        //    return new MinioClient()
        //        .WithEndpoint(minioConfig.Connection)
        //        .WithCredentials(minioConfig.AccessKey, minioConfig.SecretKey)
        //        .WithSSL(false)
        //        .Build();
        //}

        //public static async Task<bool> IsExistBucket(string bucketName)
        //{
        //    var client = GetClient();
        //    var args = new BucketExistsArgs().WithBucket(bucketName);
        //    return await client.BucketExistsAsync(args).ConfigureAwait(false);
        //}

        //public static async void CreateBucket(string bucketName)
        //{
        //    var client = GetClient();
        //    var args = new BucketExistsArgs().WithBucket(bucketName);
        //    var found = await client.BucketExistsAsync(args).ConfigureAwait(false);

        //    if (found)
        //    {
        //        throw new Exception($"{bucketName} 桶已存在");
        //    }
        //    else
        //    {
        //        var makeBucketArgs = new MakeBucketArgs().WithBucket(bucketName);
        //        await client.MakeBucketAsync(makeBucketArgs).ConfigureAwait(false);
        //    }
        //}

        ///// <summary>
        ///// 上传文件到Minio
        ///// </summary>
        ///// <param name="bucketName"></param>
        ///// <param name="fileName"></param>
        ///// <param name="file"></param>
        //public static async Task Upload(string bucketName, string fileName, IFormFile file)
        //{
        //    try
        //    {
        //        var client = GetClient();

        //        using (var stream = new MemoryStream())
        //        {
        //            await file.CopyToAsync(stream);
        //            stream.Seek(0, SeekOrigin.Begin);

        //            var putObjectArgs = new PutObjectArgs()
        //                .WithBucket(bucketName)
        //                .WithContentType(file.ContentType)
        //                .WithObject(fileName)
        //                .WithObjectSize(stream.Length)
        //                .WithStreamData(stream);

        //            await client.PutObjectAsync(putObjectArgs);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Message:{0} Source:{1} StackTrace:{2}", ex.Message, ex.Source, ex.StackTrace);

        //        //throw new CodeException(ErrorCode.UPLOAD_MINIO_FAIL, FrameworkI18N.UploadMinioFail);
        //    }
        //}

        ///// <summary>
        ///// 上传文件流到Minio
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <param name="stream"></param>
        ///// <param name="bucketName"></param>
        ///// <param name="contType"></param>
        ///// <exception cref="CodeException"></exception>
        //public static async Task Upload(
        //    string bucketName,
        //    string fileName,
        //    MemoryStream stream,
        //    string? contType)
        //{
        //    try
        //    {
        //        var client = GetClient();

        //        using (stream)
        //        {
        //            stream.Seek(0, SeekOrigin.Begin);

        //            var putObjectArgs = new PutObjectArgs()
        //                .WithBucket(bucketName)
        //                .WithObject(fileName)
        //                .WithObjectSize(stream.Length)
        //                .WithStreamData(stream);

        //            if (!contType.IsNullOrEmpty())
        //            {
        //                putObjectArgs.WithContentType(contType);
        //            }

        //            await client.PutObjectAsync(putObjectArgs);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(ex.Message);
        //        //throw new CodeException(ErrorCode.UPLOAD_MINIO_FAIL, FrameworkI18N.UploadMinioFail);
        //    }
        //}
    }
}