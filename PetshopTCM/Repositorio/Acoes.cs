using MySql.Data.MySqlClient;
using PetshopTCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetshopTCM.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();
        public Usuario TestarUsuario(Usuario u)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_usuarios where nome_usuario = @usuario and senha_usuario = @senha", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = u.nome_usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = u.senha_usuario;
            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Usuario dto = new Usuario();
                    {
                        dto.nome_usuario = Convert.ToString(leitor["NOME_USUARIO"]);
                        dto.nome_usuario = Convert.ToString(leitor["SENHA_USUARIO"]);

                    }

                }
            }
            else
            {
                u.nome_usuario = null;
                u.senha_usuario = null;

            }
            return u;
        }
        public void CadastrarServico(Servico serv)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_servicos" +
                " values ( @cod_servico, @cod_func, @cod_pet ,@desc_servico ,  @valor_servico, @status_servico)", con.MyConectarBD());
            cmd.Parameters.Add("@cod_servico", MySqlDbType.VarChar).Value = serv.cod_servico;
            cmd.Parameters.Add("@cod_func", MySqlDbType.VarChar).Value = serv.cod_func;
            cmd.Parameters.Add("@cod_pet", MySqlDbType.VarChar).Value = serv.cod_pet;
            cmd.Parameters.Add("@desc_servico", MySqlDbType.VarChar).Value = serv.desc_servico;
            cmd.Parameters.Add("@valor_servico", MySqlDbType.Decimal).Value = serv.valor_servico;
            cmd.Parameters.Add("@status_servico", MySqlDbType.VarChar).Value = serv.status_servico;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();

        }



        //MÉTODO LISTA SERVICOS
        public List<Servico> ListarServico()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbl_servicos", con.MyConectarBD());
            var dadosServico = cmd.ExecuteReader();
            return ListarServico(dadosServico);
        }

        public Servico ListarServicoCod(int cd)
        {
            var comando = string.Format("select * from tbl_servicos where cod_servico = {0}", cd);
            MySqlCommand cmd = new MySqlCommand(comando, con.MyConectarBD());
            var dadosServicoCod = cmd.ExecuteReader();
            return ListarServico(dadosServicoCod).FirstOrDefault();

        }
        public List<Servico> ListarServico(MySqlDataReader dr)
        {
            var altServico = new List<Servico>();
            while (dr.Read())
            {
                var ServicoTemp = new Servico()
                {
                    cod_servico = int.Parse(dr["cod_servico"].ToString()),
                    cod_func = int.Parse(dr["cod_func"].ToString()),
                    cod_pet = int.Parse(dr["cod_pet"].ToString()),
                    desc_servico = dr["desc_servico"].ToString(),
                    valor_servico = decimal.Parse(dr["valor_servico"].ToString()),
                    status_servico = dr["status_servico"].ToString(),

                };
                altServico.Add(ServicoTemp);
            }
            dr.Close();
            return altServico;
        }

        public void AlterarServico(Servico s)
        {
            MySqlCommand cmd = new MySqlCommand("update tbl_servicos set" +
                " cod_func=@cod_func, cod_pet=@cod_pet, desc_servico=@desc_servico," +
                " valor_servico=@valor_servico, status_servico=@status_servico" +
                " where cod_servico=@cod_servico ", con.MyConectarBD());
            cmd.Parameters.Add("@cod_servico", MySqlDbType.Int32).Value = s.cod_servico;
            cmd.Parameters.Add("@cod_func", MySqlDbType.Int32).Value = s.cod_func;
            cmd.Parameters.Add("@cod_pet", MySqlDbType.Int32).Value = s.cod_pet;
            cmd.Parameters.Add("@desc_servico", MySqlDbType.VarChar).Value = s.desc_servico;
            cmd.Parameters.Add("@valor_servico", MySqlDbType.Decimal).Value = s.valor_servico;
            cmd.Parameters.Add("@status_servico", MySqlDbType.VarChar).Value = s.status_servico;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void DeletarServico(int cd)
        {
            var comando = string.Format("delete from tbl_servicos where cod_servico = {0}", cd);
            MySqlCommand cmd = new MySqlCommand(comando, con.MyConectarBD());
            cmd.ExecuteReader();
        }

        public void Pagamento(Pagamento p)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_pagamentos" +
               " values ( @cod_id_pag, @cod_pedido, @metodo_pag ,@valor_total)", con.MyConectarBD());
            cmd.Parameters.Add("@cod_id_pag", MySqlDbType.VarChar).Value = p.cod_id_pag;
            cmd.Parameters.Add("@cod_pedido", MySqlDbType.VarChar).Value = p.cod_pedido;
            cmd.Parameters.Add("@metodo_pag", MySqlDbType.VarChar).Value = p.metodo_pag;
            cmd.Parameters.Add("@valor_total", MySqlDbType.VarChar).Value = p.valor_total;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();

        }
        public void Pedido(Pedido ped)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_pedidos" +
               " values ( @cod_pedido, @descr_pedido ,@data_pedido, @cod_cli, @cod_especie, @cod_func, @cod_id_pag, @cod_pet, @cod_raca)", con.MyConectarBD());
            cmd.Parameters.Add("@cod_pedido", MySqlDbType.VarChar).Value = ped.cod_pedido;
            cmd.Parameters.Add("@descr_pedido", MySqlDbType.VarChar).Value = ped.descr_pedido;
            cmd.Parameters.Add("@data_pedido", MySqlDbType.VarChar).Value = ped.data_pedido;
            cmd.Parameters.Add("@cod_cli", MySqlDbType.VarChar).Value = ped.cod_cli;
            cmd.Parameters.Add("@cod_especie", MySqlDbType.VarChar).Value = ped.cod_especie;
            cmd.Parameters.Add("@cod_func", MySqlDbType.VarChar).Value = ped.cod_func;
            cmd.Parameters.Add("@cod_id_pag", MySqlDbType.VarChar).Value = ped.cod_id_pag;
            cmd.Parameters.Add("@cod_pet", MySqlDbType.VarChar).Value = ped.cod_pet;
            cmd.Parameters.Add("@cod_raca", MySqlDbType.VarChar).Value = ped.cod_raca;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

    }
}
