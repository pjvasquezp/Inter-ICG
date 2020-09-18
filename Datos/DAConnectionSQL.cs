using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ICG_Inter.Properties;
using System.Windows.Forms;

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
                var sscsb = new SqlConnectionStringBuilder(Settings.Default.ConnStringSQL1);
                sscsb.ConnectTimeout = 5;
                
                Con = new SqlConnection(sscsb.ConnectionString);
                
                Con.Open();
                
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    Con.Close();
                    return Con;
                }
        }
        catch (Exception ex)
        {
                var sscsb = new SqlConnectionStringBuilder(Settings.Default.ConnStringSQL2);
                sscsb.ConnectTimeout = 5;

                Con = new SqlConnection(sscsb.ConnectionString);

                try
                {
                    Con.Open();
                    if (Con.State == System.Data.ConnectionState.Open)
                    {
                        Con.Close();
                        return Con;
                    }
                }
                catch (Exception exe)
                {
                    System.Windows.Forms.MessageBox.Show("No Es Posible Conectar con el Servidor " + 
                        exe.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               

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
