using FileSystem.Domain.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace FileSystem.API.Repositories.Files
{
    public class FileRepository : BaseRepository, IFileRepository
    {
        public FileRepository(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        public async Task<bool> CheckIfFileExistsByIdAsync(int fileId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfFileExistsById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fileId", SqlDbType.NVarChar).Value = fileId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(returnValue.Value);
                }
            }
        }

        public async Task<bool> CheckIfFileExistsInFolderAsync(string fileName, int folderId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfFileExistsInFolder", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
                    cmd.Parameters.Add("@folderId", SqlDbType.Int).Value = folderId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(returnValue.Value);
                }
            }
        }

        public async Task<Domain.Entities.File> CreateFileAsync(Domain.Entities.File file)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateFile", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = file.Name;
                    cmd.Parameters.Add("@folderId", SqlDbType.Int).Value = file.FolderId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    file.Id = (int)returnValue.Value;
                }
            }
            return file;
        }

        public async Task DeleteFileAsync(int fileId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFile", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fileId", SqlDbType.NVarChar).Value = fileId;

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<string>> GetFilesByNameAsync(string fileName, int folderId)
        {
            List<string> files = new List<string>();
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetFilesByName", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
                    cmd.Parameters.Add("@folderId", SqlDbType.NVarChar).Value = folderId;

                    connection.Open();
                    var dataReader = await cmd.ExecuteReaderAsync();
                    while (dataReader.Read())
                    {
                        files.Add(Convert.ToString(dataReader["name"]));
                    }
                }
            }
            return files;
        }
    }
}
