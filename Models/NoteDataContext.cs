using System.Data.SqlClient;
namespace notesappp.Models
{
    public class NoteDataContext
    {
        public List<Note> Allnotes()
        {
            List<Note> notes = new List<Note>();
            string cs = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Testing;Integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select * from Kaif";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
               Note note = new Note();
                note.Id = sqlDataReader.GetInt32(0);
                note.Title=sqlDataReader.GetString(1);
                note.Description=sqlDataReader.GetString(2);
                notes.Add(note);
            }
            con.Close();
            return notes;
        }


        
        public int pdata(Note note)
        {
            string cs = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Testing;Integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "insert into Kaif values(@title,@description)";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            sqlCommand.Parameters.AddWithValue("@title", note.Title);
            sqlCommand.Parameters.AddWithValue("@description",note.Description);
            int k = sqlCommand.ExecuteNonQuery();
            con.Close();

            if (k > 0)
            {
                return k;
            }
            else
            {
                return 0; 
            }
        }


        public int ddata(int id)
        {
                                            string cs = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Testing;Integrated Security=true;";
                                            SqlConnection con = new SqlConnection(cs);
                                            con.Open();
                                            string query = "delete from Kaif where id=@id";
                                            SqlCommand sqlCommand = new SqlCommand(query, con);
                                            sqlCommand.Parameters.AddWithValue("@id",id);
                                            int k = sqlCommand.ExecuteNonQuery();
                                            con.Close();
                                            if (k > 0)
                                            {
                                                return k;
                                            }
                                            else
                                            {
                                                return 0;
                                            }

        }
        
    } 
}
