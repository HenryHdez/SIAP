ALTER TABLE SE.dbo.EstacionValores ADD [Anio] INT NULL
GO
UPDATE SE.dbo.EstacionValores  SET Anio = 2014
GO
ALTER TABLE SE.dbo.EstacionValores ALTER COLUMN Anio INT NOT NULL
--


ALTER TABLE SE.dbo.EstacionValores ADD [EstacionTipoConstanteId] INT NULL
GO
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =1
WHERE EstacionValoresId = 1 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =2
WHERE EstacionValoresId = 2 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =3
WHERE EstacionValoresId = 3 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =4
WHERE EstacionValoresId = 4 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =5
WHERE EstacionValoresId = 5 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =6
WHERE EstacionValoresId = 6 
UPDATE SE.dbo.EstacionValores SET [EstacionTipoConstanteId] =7
WHERE EstacionValoresId = 7 
GO
ALTER TABLE SE.dbo.EstacionValores ALTER COLUMN [EstacionTipoConstanteId] INT NOT NULL
--


ALTER TABLE SE.dbo.EstacionConstantes
DROP CONSTRAINT [FK_dbo.EstacionConstantes_dbo.EstacionTipoConstante_EstacionTipoConstanteId]


USE [SE]
GO
DROP INDEX [IX_EstacionTipoConstanteId] ON [dbo].[EstacionConstantes]
GO

ALTER TABLE SE.dbo.EstacionConstantes
DROP COLUMN EstacionTipoConstanteId

ALTER TABLE SE.dbo.EstacionValores
 ADD CONSTRAINT [FK_dbo.EstacionValores_dbo.EstacionTipoConstante_EstacionTipoConstanteId] FOREIGN KEY ([EstacionTipoConstanteId]) REFERENCES [dbo].[EstacionTipoConstante] ([EstacionTipoConstanteId]) ON DELETE CASCADE

GO
CREATE NONCLUSTERED INDEX [IX_EstacionTipoConstanteId]
    ON SE.[dbo].[EstacionValores]([EstacionTipoConstanteId] ASC);

