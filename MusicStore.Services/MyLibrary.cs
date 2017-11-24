namespace MusicStore.Services
{
    public class MyLibrary
    {
        public static string EncodeString(string inputString)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(inputString);

            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        public static string DecodeString(string inputString)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(inputString);

            return System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
        }
    }
}