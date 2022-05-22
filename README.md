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
	a. Trades - holds all trades.
	b. StockValues - holds current stock value, and rolling totals for calculation efficiency.
2. A service - business logic, calculation extracted for testability.
3. 2x Controllers -
	a. TradesController - report new trade.
	b. StockValues - query stock values.

