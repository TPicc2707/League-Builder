using Amazon.S3;
using Amazon.S3.Model;

namespace League.Builder.Web.Server.Services;

public class AWSService : IAWSService
{
    private readonly IAmazonS3 _awsS3;
    private const string Image_S3_Bucket_Name = "league-builder-images";

    public AWSService(IAmazonS3 awsS3)
    {
        _awsS3 = awsS3 ?? throw new ArgumentNullException(nameof(awsS3));
    }

    public async Task<bool> UploadImages(string keyPath, IBrowserFile file)
    {
        PutObjectRequest s3Request = new PutObjectRequest()
        {
            InputStream = file.OpenReadStream(),
            BucketName = Image_S3_Bucket_Name,
            Key = keyPath

        };
        PutObjectResponse s3Response = await _awsS3.PutObjectAsync(s3Request);

        var response = s3Response.HttpStatusCode;

        if (response != System.Net.HttpStatusCode.OK)
            return false;


        return true;
    }

    public async Task<string> GetImage(string keyPath)
    {
        try
        {
            GetObjectRequest s3Request = new GetObjectRequest()
            {
                BucketName = Image_S3_Bucket_Name,
                Key = keyPath
            };

            GetObjectResponse s3Response = await _awsS3.GetObjectAsync(s3Request);

            using (var responseStream = s3Response.ResponseStream)
            {
                var imageBytes = ReadStream(responseStream);
                var imagesrc = Convert.ToBase64String(imageBytes);
                return string.Format("data:image/jpeg;base64,{0}", imagesrc);
            }

        }
        catch (Exception exception)
        {
            throw new Exception("Read object operation failed.", exception);
        }
    }

    private static byte[] ReadStream(Stream responseStream)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }
}

