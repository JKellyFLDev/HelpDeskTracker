/** HEADER
===============================================================================
NAME: Glenn Weber
DESCRIPTION: Returns the count of all issues for tickets in a date range.
PARAMETERS:
    @StartDate - Start date of date range -
NOTES:
HISTORY:
-------------------------------------------------------------------------------
[2020-11-20] - [gweber] - Initial Creation
===============================================================================
END HEADER **/

--EXEC [dbo].[GetIssueCountsForDateRange] '2020-11-20', '2020-11-23'

USE [HelpDeskData]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
        INNER JOIN dbo.TicketIssue TI ON T.Id = TI.TicketId
        INNER JOIN dbo.Issues I ON I.Id = TI.IssueId
    WHERE T.DateOpen BETWEEN @StartDate AND @EndDate
    GROUP BY
        I.Id, I.Name
GO
