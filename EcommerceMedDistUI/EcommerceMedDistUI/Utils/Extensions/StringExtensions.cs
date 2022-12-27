namespace EcommerceMedDistUI.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string FormatDocument(this string document)
        {
            if (document.Length == 14)
                return FormatCNPJ(document);
            else if (document.Length == 11)
                return FormatCPF(document);
            else
                return "Documento formato desconhecido";
        }

        public static string FormatCNPJ(string CNPJ)
        {
            return Convert.ToUInt64(CNPJ).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormatCPF(string CPF)
        {
            return Convert.ToUInt64(CPF).ToString(@"000\.000\.000\-00");
        }

        public static string SemFormatacao(string Codigo)
        {
            return Codigo.Replace(".", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty);
        }
    }
}
