namespace business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Iniciando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Celula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Dia_semana = c.String(nullable: false),
                        Horario = c.Time(nullable: false, precision: 7),
                        Maximo_pessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnderecoCelula",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Pais = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Bairro = c.String(nullable: false),
                        Rua = c.String(nullable: false),
                        Numero_casa = c.Int(nullable: false),
                        Cep = c.Long(nullable: false),
                        Complemento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MinisterioCelula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CelulaId = c.Int(nullable: false),
                        MinisterioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.CelulaId)
                .ForeignKey("dbo.Ministerio", t => t.MinisterioId)
                .Index(t => t.CelulaId)
                .Index(t => t.MinisterioId);
            
            CreateTable(
                "dbo.Ministerio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Proposito = c.String(nullable: false),
                        Ministro_ = c.Int(),
                        Maximo_pessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PessoaMinisterio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        MinisterioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.MinisterioId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId)
                .Index(t => t.MinisterioId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePessoa = c.String(),
                        Codigo = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 80),
                        Falta = c.Int(nullable: false),
                        celula_ = c.Int(),
                        Img = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.celula_)
                .Index(t => t.Codigo, unique: true, name: "CODIGO")
                .Index(t => t.Email, unique: true, name: "EMAIL")
                .Index(t => t.celula_);
            
            CreateTable(
                "dbo.Chamada",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_inicio = c.DateTime(nullable: false),
                        Numero_chamada = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Historico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data_inicio = c.DateTime(nullable: false),
                        pessoaid = c.Int(nullable: false),
                        Falta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.pessoaid)
                .Index(t => t.pessoaid);
            
            CreateTable(
                "dbo.ReuniaoPessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaId = c.Int(nullable: false),
                        ReuniaoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Reuniao", t => t.ReuniaoId)
                .Index(t => t.PessoaId)
                .Index(t => t.ReuniaoId);
            
            CreateTable(
                "dbo.Reuniao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data_reuniao = c.DateTime(nullable: false),
                        Horario_inicio = c.Time(nullable: false, precision: 7),
                        Horario_fim = c.Time(nullable: false, precision: 7),
                        Local_reuniao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Pais = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Cidade = c.String(nullable: false),
                        Bairro = c.String(nullable: false),
                        Rua = c.String(nullable: false),
                        Numero_casa = c.Int(nullable: false),
                        Cep = c.Long(nullable: false),
                        Complemento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaDado", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Fone = c.String(),
                        Celular = c.String(),
                        Whatsapp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaDado", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MudancaEstado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        velhoEstado = c.String(),
                        novoEstado = c.String(),
                        DataMudanca = c.DateTime(nullable: false),
                        CodigoPessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PessoaDado",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_nascimento = c.DateTime(nullable: false),
                        Rg = c.String(nullable: false),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Estado_civil = c.String(nullable: false),
                        Sexo_masculino = c.Boolean(nullable: false),
                        Sexo_feminino = c.Boolean(nullable: false),
                        Falescimento = c.Boolean(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Cpf, unique: true, name: "CPF");
            
            CreateTable(
                "dbo.Membro",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_batismo = c.Int(nullable: false),
                        Desligamento = c.Boolean(nullable: false),
                        Motivo_desligamento = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaDado", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_Aclamacao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Denominacao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membro", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_Batismo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membro", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_Reconciliacao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_reconciliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membro", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_Transferencia",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome_cidade_transferencia = c.String(nullable: false),
                        Estado_transferencia = c.String(nullable: false),
                        Nome_igreja_transferencia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Membro", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Crianca",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome_pai = c.String(nullable: false),
                        Nome_mae = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaDado", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Visitante",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_visita = c.DateTime(nullable: false),
                        Condicao_religiosa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaDado", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.PessoaLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pessoa", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MembroLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_batismo = c.Int(nullable: false),
                        Desligamento = c.Boolean(nullable: false),
                        Motivo_desligamento = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_AclamacaoLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Denominacao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembroLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_BatismoLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembroLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_ReconciliacaoLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_reconciliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembroLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Membro_TransferenciaLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome_cidade_transferencia = c.String(nullable: false),
                        Estado_transferencia = c.String(nullable: false),
                        Nome_igreja_transferencia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembroLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CriancaLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome_pai = c.String(nullable: false),
                        Nome_mae = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.VisitanteLgpd",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Data_visita = c.DateTime(nullable: false),
                        Condicao_religiosa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PessoaLgpd", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Lider_Celula",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Lider_Celula_Treinamento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Lider_Ministerio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Lider_Ministerio_Treinamento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Supervisor_Celula",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Maximo_celula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Supervisor_Celula_Treinamento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Maximo_celula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Supervisor_Ministerio",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Maximo_celula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Supervisor_Ministerio_Treinamento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Maximo_celula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ministerio", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Celula_Adolescente",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Celula_Adulto",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Celula_Casado",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Celula_Crianca",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Celula_Jovem",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Celula", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Celula_Jovem", "Id", "dbo.Celula");
            DropForeignKey("dbo.Celula_Crianca", "Id", "dbo.Celula");
            DropForeignKey("dbo.Celula_Casado", "Id", "dbo.Celula");
            DropForeignKey("dbo.Celula_Adulto", "Id", "dbo.Celula");
            DropForeignKey("dbo.Celula_Adolescente", "Id", "dbo.Celula");
            DropForeignKey("dbo.Supervisor_Ministerio_Treinamento", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Supervisor_Ministerio", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Supervisor_Celula_Treinamento", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Supervisor_Celula", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Lider_Ministerio_Treinamento", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Lider_Ministerio", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Lider_Celula_Treinamento", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.Lider_Celula", "Id", "dbo.Ministerio");
            DropForeignKey("dbo.VisitanteLgpd", "Id", "dbo.PessoaLgpd");
            DropForeignKey("dbo.CriancaLgpd", "Id", "dbo.PessoaLgpd");
            DropForeignKey("dbo.Membro_TransferenciaLgpd", "Id", "dbo.MembroLgpd");
            DropForeignKey("dbo.Membro_ReconciliacaoLgpd", "Id", "dbo.MembroLgpd");
            DropForeignKey("dbo.Membro_BatismoLgpd", "Id", "dbo.MembroLgpd");
            DropForeignKey("dbo.Membro_AclamacaoLgpd", "Id", "dbo.MembroLgpd");
            DropForeignKey("dbo.MembroLgpd", "Id", "dbo.PessoaLgpd");
            DropForeignKey("dbo.PessoaLgpd", "Id", "dbo.Pessoa");
            DropForeignKey("dbo.Visitante", "Id", "dbo.PessoaDado");
            DropForeignKey("dbo.Crianca", "Id", "dbo.PessoaDado");
            DropForeignKey("dbo.Membro_Transferencia", "Id", "dbo.Membro");
            DropForeignKey("dbo.Membro_Reconciliacao", "Id", "dbo.Membro");
            DropForeignKey("dbo.Membro_Batismo", "Id", "dbo.Membro");
            DropForeignKey("dbo.Membro_Aclamacao", "Id", "dbo.Membro");
            DropForeignKey("dbo.Membro", "Id", "dbo.PessoaDado");
            DropForeignKey("dbo.PessoaDado", "Id", "dbo.Pessoa");
            DropForeignKey("dbo.MinisterioCelula", "MinisterioId", "dbo.Ministerio");
            DropForeignKey("dbo.PessoaMinisterio", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Telefone", "Id", "dbo.PessoaDado");
            DropForeignKey("dbo.Endereco", "Id", "dbo.PessoaDado");
            DropForeignKey("dbo.ReuniaoPessoa", "ReuniaoId", "dbo.Reuniao");
            DropForeignKey("dbo.ReuniaoPessoa", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Historico", "pessoaid", "dbo.Pessoa");
            DropForeignKey("dbo.Chamada", "Id", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "celula_", "dbo.Celula");
            DropForeignKey("dbo.PessoaMinisterio", "MinisterioId", "dbo.Ministerio");
            DropForeignKey("dbo.MinisterioCelula", "CelulaId", "dbo.Celula");
            DropForeignKey("dbo.EnderecoCelula", "Id", "dbo.Celula");
            DropIndex("dbo.Celula_Jovem", new[] { "Id" });
            DropIndex("dbo.Celula_Crianca", new[] { "Id" });
            DropIndex("dbo.Celula_Casado", new[] { "Id" });
            DropIndex("dbo.Celula_Adulto", new[] { "Id" });
            DropIndex("dbo.Celula_Adolescente", new[] { "Id" });
            DropIndex("dbo.Supervisor_Ministerio_Treinamento", new[] { "Id" });
            DropIndex("dbo.Supervisor_Ministerio", new[] { "Id" });
            DropIndex("dbo.Supervisor_Celula_Treinamento", new[] { "Id" });
            DropIndex("dbo.Supervisor_Celula", new[] { "Id" });
            DropIndex("dbo.Lider_Ministerio_Treinamento", new[] { "Id" });
            DropIndex("dbo.Lider_Ministerio", new[] { "Id" });
            DropIndex("dbo.Lider_Celula_Treinamento", new[] { "Id" });
            DropIndex("dbo.Lider_Celula", new[] { "Id" });
            DropIndex("dbo.VisitanteLgpd", new[] { "Id" });
            DropIndex("dbo.CriancaLgpd", new[] { "Id" });
            DropIndex("dbo.Membro_TransferenciaLgpd", new[] { "Id" });
            DropIndex("dbo.Membro_ReconciliacaoLgpd", new[] { "Id" });
            DropIndex("dbo.Membro_BatismoLgpd", new[] { "Id" });
            DropIndex("dbo.Membro_AclamacaoLgpd", new[] { "Id" });
            DropIndex("dbo.MembroLgpd", new[] { "Id" });
            DropIndex("dbo.PessoaLgpd", new[] { "Id" });
            DropIndex("dbo.Visitante", new[] { "Id" });
            DropIndex("dbo.Crianca", new[] { "Id" });
            DropIndex("dbo.Membro_Transferencia", new[] { "Id" });
            DropIndex("dbo.Membro_Reconciliacao", new[] { "Id" });
            DropIndex("dbo.Membro_Batismo", new[] { "Id" });
            DropIndex("dbo.Membro_Aclamacao", new[] { "Id" });
            DropIndex("dbo.Membro", new[] { "Id" });
            DropIndex("dbo.PessoaDado", "CPF");
            DropIndex("dbo.PessoaDado", new[] { "Id" });
            DropIndex("dbo.Telefone", new[] { "Id" });
            DropIndex("dbo.Endereco", new[] { "Id" });
            DropIndex("dbo.ReuniaoPessoa", new[] { "ReuniaoId" });
            DropIndex("dbo.ReuniaoPessoa", new[] { "PessoaId" });
            DropIndex("dbo.Historico", new[] { "pessoaid" });
            DropIndex("dbo.Chamada", new[] { "Id" });
            DropIndex("dbo.Pessoa", new[] { "celula_" });
            DropIndex("dbo.Pessoa", "EMAIL");
            DropIndex("dbo.Pessoa", "CODIGO");
            DropIndex("dbo.PessoaMinisterio", new[] { "MinisterioId" });
            DropIndex("dbo.PessoaMinisterio", new[] { "PessoaId" });
            DropIndex("dbo.MinisterioCelula", new[] { "MinisterioId" });
            DropIndex("dbo.MinisterioCelula", new[] { "CelulaId" });
            DropIndex("dbo.EnderecoCelula", new[] { "Id" });
            DropTable("dbo.Celula_Jovem");
            DropTable("dbo.Celula_Crianca");
            DropTable("dbo.Celula_Casado");
            DropTable("dbo.Celula_Adulto");
            DropTable("dbo.Celula_Adolescente");
            DropTable("dbo.Supervisor_Ministerio_Treinamento");
            DropTable("dbo.Supervisor_Ministerio");
            DropTable("dbo.Supervisor_Celula_Treinamento");
            DropTable("dbo.Supervisor_Celula");
            DropTable("dbo.Lider_Ministerio_Treinamento");
            DropTable("dbo.Lider_Ministerio");
            DropTable("dbo.Lider_Celula_Treinamento");
            DropTable("dbo.Lider_Celula");
            DropTable("dbo.VisitanteLgpd");
            DropTable("dbo.CriancaLgpd");
            DropTable("dbo.Membro_TransferenciaLgpd");
            DropTable("dbo.Membro_ReconciliacaoLgpd");
            DropTable("dbo.Membro_BatismoLgpd");
            DropTable("dbo.Membro_AclamacaoLgpd");
            DropTable("dbo.MembroLgpd");
            DropTable("dbo.PessoaLgpd");
            DropTable("dbo.Visitante");
            DropTable("dbo.Crianca");
            DropTable("dbo.Membro_Transferencia");
            DropTable("dbo.Membro_Reconciliacao");
            DropTable("dbo.Membro_Batismo");
            DropTable("dbo.Membro_Aclamacao");
            DropTable("dbo.Membro");
            DropTable("dbo.PessoaDado");
            DropTable("dbo.MudancaEstado");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Reuniao");
            DropTable("dbo.ReuniaoPessoa");
            DropTable("dbo.Historico");
            DropTable("dbo.Chamada");
            DropTable("dbo.Pessoa");
            DropTable("dbo.PessoaMinisterio");
            DropTable("dbo.Ministerio");
            DropTable("dbo.MinisterioCelula");
            DropTable("dbo.EnderecoCelula");
            DropTable("dbo.Celula");
        }
    }
}
