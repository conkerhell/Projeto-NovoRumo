
USE [NovoRumo]
GO

/****** Object:  Table [dbo].[Politics]    Script Date: 25/06/2018 11:06:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Policy](
	[PolicyID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_Policy] PRIMARY KEY CLUSTERED 
(
	[PoliticsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Policy  (
Title,
Description) VALUES (1,'Política de Privacidade',
'Nosso Compromisso com Você
    MÉDICOS SEM FRONTEIRAS BRASIL (MSF Brasil) está fortemente empenhada em proteger a privacidade dos seus doadores.
    Queremos ajudá-lo a entender melhor as informações que recolhemos, como lidamos com ela, e as opções que você tem em relação a como as utilizamos.
    Essa Política de Privacidade é aplicada quando recebemos um cadastro para doação para Médicos Sem Fronteiras (online ou não).
    Ao se cadastrar para doar para MSF Brasil, você está aceitando esta Política de Privacidade, da qual fornecemos cópias mediante solicitação.
    
    Coleta de Informações
    
    MSF só coleta suas informações se forem fornecidas voluntariamente, através de contato via e-mail, formulário de doações on-line, por telefone, registro no site, ou qualquer outro meio que encontremos para facilitar sua interação conosco.
    
    Eventualmente fazemos locação de listas para envio de mala direta com o objetivo de conseguir novos doadores para apoiar nosso trabalho. Não teremos acesso a esses dados até que, espontaneamente, a pessoa que recebeu nossa comunicação faça uma doação. Nesse momento, receberemos da empresa locadora os dados do novo doador e assim este passa a fazer parte de nosso banco de dados e a receber nossas informações. Só trabalhamos com listas legalizadas e que usem dados previamente autorizados pelos respectivos donos.
    
    Outra possibilidade de coleta de dados é através de empresas especializadas em tratamento ou higienização de dados (em inglês usa-se os termos data cleansing ou data scrubbing), que é o ato de detectar, remover e/ou corrigir dados sujos de uma base de dados. Por dados sujos entendem-se incorretos, desatualizados, redundantes, incompletos ou formatados incorretamente. Essas empresas podem nos ajudar a completar seu cadastro.
    
    Caso façamos contato com você, ou você faça conosco, via chat online, telefone, sms, email ou fórum em nosso site, podemos pedir-lhe informações pessoais como o seu nome, CPF, código de doador e endereço de e-mail para facilitar a busca de seu cadastro e/ou confirmar sua identificação.
    
    Poderemos coletar algumas informações como IP (Internet Protocol – Endereço do computador na internet usado no momento de acesso ao site), tipo de navegador e sistema operacional, apenas para fins de análise estatística sobre o site. Não fazemos nenhuma tentativa de vincular estes dados com a identidade dos indivíduos que visitam nosso site.
    
    Caso não queira mais receber nossos e-mails, basta clicar no link ao final das mensagens e seguir as instruções para&nbsp; solicitar o cancelamento do cadastro.
    
    Proteção e Segurança de Dados
    
    A qualquer momento seu direito fundamental à autodeterminação informativa pode ser exercido caso queira.
    
    O direito de autodeterminação informativa pode ser compreendido como&nbsp; o direito da pessoa sobre o controle de seus dados pessoais, que garante que o titular possa acessar, retificar e anular seus dados pessoais armazenados em bancos de dados (públicos ou privados).
    
    Quando você nos envia informações de pagamento através de formulário on-line em nosso site, as informações são transmitidas usando o protocolo https e protegidas por&nbsp; um alto grau de criptografia. Exigimos que todos os processamentos de crédito e transações de cartão recebidas em nosso nome atendam os seguintes padrões: criptografia de nível alto (RC4, chaves de 128 bits), homologado por GeoTrust SSL CA.
    
    Suas informações pessoais a nós fornecidas serão armazenadas em local seguro e acessível somente a funcionários designados e treinados no manuseio das informações dos doadores.
    
    Usamos medidas de segurança técnica e organizacional para proteger seus dados contra manipulação, perda, destruição ou acesso por pessoas não autorizadas. Somente as pessoas selecionadas têm acesso aos dados e são legal e contratualmente obrigadas a tratá-los como confidenciais.
    
    Uso das Informações
    Médicos Sem Fronteiras preza por manter os mais altos padrões de ética na forma de arrecadar fundos. Não vendemos ou alugamos nosso banco de dados para quaisquer outras organizações, ou empresas, sejam elas parceiras ou não de MSF Brasil.&nbsp; As informações pessoais dos doadores permanecerão confidenciais e só poderão ser utilizadas por funcionários autorizados de MSF Brasil para realizar o processamento de doações, manter o doador informado sobre nossos projetos e atividades, corrigir dados de cadastro e para pedir sua ajuda em nossa missão de salvar vidas e aliviar o sofrimento humano.
    
    Além disso, podemos usar estas informações para melhorar nosso marketing e esforços promocionais (como, por exemplo, para saber se a maioria dos nossos doadores é mulher ou homem, ou para avaliar as regiões do país onde há uma concentração de pessoas comprometidas com a nossa causa), mantê-lo atualizado sobre o nosso trabalho, analisar o uso do site, e melhorar seu conteúdo, layout e serviços.
    
    Atualizando suas Informações
    Trabalhamos para processar e manter com precisão as informações que nossos doadores compartilham conosco.
    
    Se você é nosso doador e gostaria de corrigir/atualizar seus dados pessoais ou ajustar suas preferências de correio, entre em contato através do atendimento ao doador pelo telefone 0800 940 3585 ou pelo endereço de email: <a href="mailto:doador@msf.org.br">doador@msf.org.br</a>. Você também pode acessar a área restrita para doadores no site de MSF Brasil - <a href="https://www.msf.org.br/login">Área do Doador</a> - utilizando seu código de doador e o e-mail cadastrado conosco.
    
    Navegação no Site <a href="http://www.msf.org.br" target="_self">www.msf.org.br</a>
    Médicos Sem Fronteiras não coleta qualquer informação de identificação pessoal quando você visita nossos sites a menos que você opte por fornecer essas informações para nós.As informações que coletamos durante a navegação, vem de duas fontes: os logs do servidor poderão coletar informações como o endereço IP (Internet Protocol), nome de domínio, tipo de navegador, sistema operacional, e informações como o site de origem da sua visita, os arquivos que você baixou, as páginas que você visitou, e as datas e horários dessas visitas. Essas informações não serão associadas a você, mas simplesmente utilizadas para fins de análise estatística e realização de melhorias nos nossos esforços de comunicação on-line.
    
    Cookies
    MSF pode coletar e analisar informações sobre o uso geral e individual do(s) nosso(s)site (s), tais como domínio, hits, páginas visitadas, o site pelo qual o visitante chegou ao nosso site, e a duração da sua visita.Nós usamos cookies, pequenos arquivos de armazenamento de dados, para saber a freqüência de uso e número de usuários em nosso site. Os cookies não armazenam informações pessoais sem que você as tenha fornecido e não coletam informações registradas em seu computador. O uso de nosso website é possível sem cookies. A maioria dos navegadores são inicialmente configurados para aceitar cookies.Você pode desativar o armazenamento de cookies ou ajustar seu navegador para notificá-lo quando os cookies estão sendo enviados.
')

USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spGetPolitics]    Script Date: 25/06/2018 11:05:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetPolicy]
	
AS
BEGIN
	--
	SELECT TOP 1 Title,Description from dbo.Policy WITH (NOLOCK)
END
GO


USE [NovoRumo]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePolitics]    Script Date: 25/06/2018 11:06:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdatePolicy]
	-- Add the parameters for the stored procedure here
	@PoliticsID as int,
	@Title as varchar(20),
	@Description as varchar(3000)
AS
BEGIN
	UPDATE Policy 
   SET Title = @Title,
	   Description = @Description	   
 WHERE PoliticsID = @PoliticsID
END
GO


