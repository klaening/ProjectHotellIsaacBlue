﻿CREATE TABLE [dbo].[DEPARTMENTS] (
    [ID]      SMALLINT     IDENTITY (1, 1) NOT NULL,
    [DEPNAME] VARCHAR (40) NOT NULL,
    CONSTRAINT [PK_DEPARTMENTS] PRIMARY KEY CLUSTERED ([ID] ASC)
);

