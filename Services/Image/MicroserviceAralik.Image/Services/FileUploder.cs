
using Amazon.S3;
using Amazon.S3.Model;

namespace MicroserviceAralik.Image.Services;

public class FileUploder(IConfiguration _configuration) : IFileUploder
{
    public async Task<string> UploadFile(IFormFile formFile)
    {
        AWSSettings? awsSettings = _configuration.GetSection("AWSSettings").Get<AWSSettings>();

        AmazonS3Config s3Config = new AmazonS3Config()
        {
            ForcePathStyle = true,
            ServiceURL = awsSettings.ServiceUrl
        };

        AmazonS3Client s3Client = new AmazonS3Client(awsSettings.AccessKeyId, awsSettings.SecretAccessKey, s3Config);


        string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName));

        using (FileStream stream = new FileStream(tempFilePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);

        }


        PutObjectRequest putRequest = new PutObjectRequest
        {
            BucketName = awsSettings.BucketName,
            Key = Path.GetFileName(tempFilePath),
            FilePath = tempFilePath,
            AutoCloseStream = true,
            DisablePayloadSigning = true,
            StreamTransferProgress = new EventHandler<Amazon.Runtime.StreamTransferProgressArgs>
            ((sender, args) =>
            {
                Console.WriteLine($"{args.PercentDone} {args.TransferredBytes} Total Byte{args.TotalBytes}");

            })
        };


        try
        {
            PutObjectResponse response = await s3Client.PutObjectAsync(putRequest);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"{awsSettings.Domain}/{putRequest.Key}";
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }


        return null;

    }
}
