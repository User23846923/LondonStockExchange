# London Stock Exchange API

An MVP stock value (volume weighted average price) API.


## Interface

**POST /api/Trades**
Report a new trade.

**GET /api/StockValues**
Query all stock values.

**GET /api/StockValues/ticker;ticker;ticker**
Query selected stock values.


## Implementation

1. A simple "database" with two tables -
	1. Trades - holds all trades.
	1. StockValues - holds current stock value, and rolling totals for calculation efficiency.
1. A service for business logic, with vwap calculation extracted for testability.
1. 2x Controllers -
	1. TradesController - report new trade.
	1. StockValuesController - query stock values.

