use SEMapa
go

ALTER TABLE dbo.Usuario
ADD Actividad NVARCHAR(255) NOT NULL DEFAULT 'No Definido', 
Institucion NVARCHAR(255) NOT NULL DEFAULT 'No Definido',
PaisId INT NOT NULL DEFAULT '1',
DepartamentoId INT NULL; 
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Usuario_dbo.Pais_PaisId] FOREIGN KEY([PaisId])
REFERENCES [dbo].[Pais] ([PaisId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_dbo.Usuario_dbo.Pais_PaisId]
GO

ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Usuario_dbo.Departamento_DepartamentoId] FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamento] ([DepartamentoId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_dbo.Usuario_dbo.Departamento_DepartamentoId]
GO