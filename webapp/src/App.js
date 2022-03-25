import React from 'react';
import {
  Route,
  Routes,
  BrowserRouter
} from 'react-router-dom'
import './App.css';
import CoinsListPage from './coinslistpage/CoinsListPage'
import CoinInfoPage from './coininfopage/CoinInfoPage'
import NotFoundPage from './notfoundpage/NotFoundPage'

class App extends React.Component {
  render() {

    const appElement =
      <div className="App">
        <header className="App-header">
          <span><p>Coin Watch</p></span>
        </header>

        <div className="App-container">
          <BrowserRouter>
            <Routes>
              <Route exact path="/info" element={<CoinInfoPage />} />
              <Route exact path="/" element={<CoinsListPage><div></div></CoinsListPage>} />
              <Route path="*" element={<NotFoundPage />} />
            </Routes>
          </BrowserRouter>
        </div>
      </div>;

    return appElement;
  }
}

export default App;
