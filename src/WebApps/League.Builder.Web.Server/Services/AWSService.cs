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
        try
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
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> CopyObjectToNewFolder(string sourceKeyPath, string destinationKeyPath)
    {
        CopyObjectRequest s3Request = new CopyObjectRequest()
        {
            SourceKey = sourceKeyPath,
            SourceBucket = Image_S3_Bucket_Name,
            DestinationBucket = Image_S3_Bucket_Name,
            DestinationKey = destinationKeyPath

        };
        CopyObjectResponse s3Response = await _awsS3.CopyObjectAsync(s3Request);

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

    public async Task DeleteObject(string keyPath)
    {
        try
        {
            DeleteObjectRequest s3Request = new DeleteObjectRequest()
            {
                BucketName = Image_S3_Bucket_Name,
                Key = keyPath
            };

            DeleteObjectResponse s3Response = await _awsS3.DeleteObjectAsync(s3Request);

            var test = s3Response.DeleteMarker;
        }
        catch (Exception exception)
        {
            throw new Exception("Deleting folder operation failed.", exception);
        }
    }

    public async Task DeleteObjects(string keyPath)
    {
        try
        {
            ListObjectsV2Request s3Request = new ListObjectsV2Request()
            {
                BucketName = Image_S3_Bucket_Name,
                Prefix = keyPath
            };

            ListObjectsV2Response s3Response = await _awsS3.ListObjectsV2Async(s3Request);

            foreach(var s3Object in s3Response.S3Objects)
            {
                DeleteObjectRequest deleteS3ObjectRequest = new DeleteObjectRequest()
                {
                    BucketName = Image_S3_Bucket_Name,
                    Key = s3Object.Key
                };

                DeleteObjectResponse deleteS3ObjectResponse = await _awsS3.DeleteObjectAsync(deleteS3ObjectRequest);

            }
        }
        catch (Exception exception)
        {
            throw new Exception("Deleting folder operation failed.", exception);
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

