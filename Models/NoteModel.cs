using Microsoft.AspNetCore.Http.HttpResults;

namespace DZ_ASPNetCore_Modul_2_3.Models
{
    public class NoteModel
    {
        public string? title { get; set; }
        public string? text { get; set; }
        public string? date { get; set; }
        public string? teg { get; set; }

        public NoteModel()
        {
            date = DateTime.Now.ToShortDateString();
        }

        public NoteModel(string? title, string? text, string? date, string? teg) : base()
        {
            this.title = title;
            this.text = text;
            this.date = date;
            this.teg = teg;
        }

        public override string? ToString()
        {
            return $"Название заметки:\r\n    {title}\r\n" +
                $"Текст заметки:\r\n    {text}\r\n" +
                $"Дата создания/изменения заметки:\r\n    {date}\r\n" +
                $"Тег заметки:\r\n    {teg}\r\n\n";
        }
    }
}
