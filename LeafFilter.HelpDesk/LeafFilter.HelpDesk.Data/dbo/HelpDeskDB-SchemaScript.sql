/** HEADER
===============================================================================
NAME: James Kelly
DESCRIPTION: Builds out all SQL objects not handled by entity framework core
NOTES:
HISTORY:
-------------------------------------------------------------------------------
[2020-11-23] - [jkelly] - Initial Creation
===============================================================================
END HEADER **/

USE [HelpDeskData]
GO

/* SQL PROCEDURES */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('dbo.GetAllTicketsCountsByDay', 'P') IS NOT NULL
	DROP PROCEDURE [dbo].[GetAllTicketsCountsByDay]
GO
CREATE PROCEDURE [dbo].[GetAllTicketsCountsByDay]
AS
    SELECT
        CAST(T.DateOpened AS DATE) AS 'DateOpened',
        DATENAME(dw,T.DateOpened) AS 'DayOfTheWeek',
        COUNT(DATENAME(dw,T.DateOpened)) AS 'Count'
    FROM dbo.Tickets T
    GROUP BY
        CAST(T.DateOpened AS DATE),
        DATENAME(dw,T.DateOpened)
GO
IF OBJECT_ID('dbo.GetIssueCountsForDateRange', 'P') IS NOT NULL
	DROP PROCEDURE [dbo].[GetIssueCountsForDateRange]
GO
CREATE PROCEDURE [dbo].[GetIssueCountsForDateRange]
(
    @StartDate DATE = NULL,
    @EndDate DATE = NULL
)
AS
    IF (@StartDate IS NULL)
        SET @StartDate = '2020-01-01'

    IF (@EndDate IS NULL)
        SET @EndDate = CAST(GETDATE() AS DATE)

    SELECT
        I.Id AS 'IssueId',
        I.Name AS 'Name',
        COUNT(I.Id) AS 'Count'
    FROM dbo.Tickets T
        INNER JOIN dbo.TicketIssueXRef TI ON T.Id = TI.TicketId
        INNER JOIN dbo.Issues I ON I.Id = TI.IssueId
    WHERE T.DateOpened BETWEEN @StartDate AND @EndDate
    GROUP BY
        I.Id, I.Name
GO
