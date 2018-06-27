

CREATE TABLE [dbo].[Terms](
	[TermID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_Terms] PRIMARY KEY CLUSTERED 
(
	[TermID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[spUpdateTerms]
	-- Add the parameters for the stored procedure here
	@TermID as int,
	@Title as varchar(20),
	@Description as varchar(3000)
AS
BEGIN
	UPDATE Terms 
   SET Title = @Title,
	   Description = @Description	   
 WHERE TermID = @TermID
END
GO

CREATE PROCEDURE [dbo].[spGetTerms]
	
AS
BEGIN
	--
	SELECT TOP 1 Title,Description from dbo.Terms WITH (NOLOCK)
END
GO


USE [NovoRumo]
GO

INSERT INTO [dbo].[Terms]
           ([Title]
           ,[Description])
     VALUES
           ('Termos de uso','Todo o conteúdo nas páginas com domínio msf.org.br é propriedade de Médicos Sem Fronteiras Brasil.
    Este conteúdo está protegido com direitos reservados e outras leis de propriedade intelectual.
    Informações publicadas nesse site podem ser dispostas, reformuladas e impressas somente para uso pessoal e não-comercial.
    É vetada a reprodução deste conteúdo, integral ou parcial, de qualquer forma, sem aprovação por escrito de MSF, salvo quando:
    
    - Podem ser feitas cópias únicas do conteúdo disponível no site, somente para uso pessoal e não-comercial, preservando os direitos reservados e outras leis associadas. É vetada a distribuição destas cópias a terceiros, sob suporte eletrônico ou não, sem o consentimento dos proprietários do material.
    
    Você pode requerer permissão para reproduzir e distribuir o conteúdo deste website entrando em contato com
   comunicacao@rio.msf.org
    
    EXCLUSÃO DE GARANTIAS E RESPONSABILIDADE
    
    Devido a grande quantidade de informação disponível no site, e às falhas inerentes a alguns tipos de distribuição eletrônica, pode ser que ocorram atrasos e inexatidão na disposição de alguns destes dados.
    &nbsp;
    
    LINKS PARA ESTE SITE
    
    Você pode estabelecer um hiperlink para este site de sua página, desde que o link esteja atribuído ao site de MSF e não indique apoio ou patrocínio da organização ao seu site. Sem autorização por escrito de MSF, você não pode utilizar, por completo ou em parte, o conteúdo deste site no link, ou incorporar material protegido por direitos autorais ou de propriedade intelectual de MSF.
    
    A logomarca de MSF faz parte deste material, e não pode ser alterada. Para utilizar a logo de MSF em seu site, entre em contato com&nbsp;
    comunicacao@rio.msf.org')
GO

