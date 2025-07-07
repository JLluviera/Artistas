namespace Artistas.Helpers
{
    public class HelperConstraseña
    {
        public static string EncryptContra (string contra)
        {
            if ( contra == null)
            {
                return "";
            }

            return BCrypt.Net.BCrypt.HashPassword(contra);
        }

        public static bool Verificar(string contra, string contraHash)
        {
            if (string.IsNullOrEmpty(contra))
            {
                return false;
            }

            return BCrypt.Net.BCrypt.Verify(contra, contraHash);
        }
    }
}
