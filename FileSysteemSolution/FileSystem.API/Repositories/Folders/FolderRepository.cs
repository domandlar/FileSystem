using FileSystem.API.Entities;
using FileSystem.API.Models;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace FileSystem.API.Repositories.Folders
{
    public class FolderRepository : BaseRepository, IFolderRepository
    {
        public FolderRepository(IOptions<AppSettings> appSettings) : base(appSettings)
        {
        }

        public async Task<bool> CheckIfFolderExistsInFolderAsync(string folderName, int parentId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfFolderExistsInFolder", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@folderName", SqlDbType.NVarChar).Value = folderName;
                    cmd.Parameters.Add("@parentId", SqlDbType.Int).Value = parentId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(returnValue.Value);
                }
            }
        }

        public async Task<Folder> CreateFolderAsync(Folder folder)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateFolder", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@folderName", SqlDbType.NVarChar).Value = folder.Name;
                    cmd.Parameters.Add("@parentId", SqlDbType.Int).Value = folder.ParentId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    folder.Id = (int)returnValue.Value;
                }
            }
            return folder;
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteFolder", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@folderId", SqlDbType.NVarChar).Value = folderId;

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<bool> CheckIfFolderExistsByIdAsync(int folderId)
        {
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CheckIfFolderExistsById", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@folderId", SqlDbType.NVarChar).Value = folderId;

                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);

                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();

                    return Convert.ToBoolean(returnValue.Value);
                }
            }
        }
    }
}
