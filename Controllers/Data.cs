using DZ_ASPNetCore_Modul_2_3.Models;

namespace DZ_ASPNetCore_Modul_2_3.Controllers
{
    public class Data
    {
        public static List<NoteModel>? notes = new List<NoteModel>();
        static Data()
        {
            notes.Add(new NoteModel("ДЗ", "Сделать домашнее задание", "04.11.2024", "#домашка"));
            notes.Add(new NoteModel("ДЗ_2", "Сделать домашнее задание", "05.11.2024", "#домашка"));
        }
    }
}
