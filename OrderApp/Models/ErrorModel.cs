using System.Text.Json;

namespace OrderApp.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Статус ошибки: {StatusCode} \n Ошибка: {Message} ";
        }
    }
}
