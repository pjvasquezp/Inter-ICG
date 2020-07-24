using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ICG_Inter.Properties;

namespace ICG_Inter.Datos
{
    
public class DAConnectionSQL
{
    public SqlConnection Con = new SqlConnection();
    public SqlTransaction Tran;
    public DAConnectionSQL()
    {
        DASQLConnection();
    }


    public SqlConnection DASQLConnection()
    {
        try
        {
                Con = new SqlConnection(Settings.Default.ConnStringSQL1);
        }
        catch (Exception ex)

        {
        }

        return Con;
    }

    public void Open()
    {
        try
        {
            Con.Open();
        }
        catch (Exception ex)
        {
        }
    }

    public void Close()
    {
        try
        {
            Con.Close();
        }
        catch (Exception ex)
        {
        }
    }

    public SqlTransaction BeginTransaction()
    {
        Tran = Con.BeginTransaction();
        return Tran;
    }

    public void CommitTransaction()
    {
        if (Tran != null)
            Tran.Commit();
    }

    public void RollBackTransaction()
    {
        if (Tran != null)
            Tran.Rollback();
    }
}

}
