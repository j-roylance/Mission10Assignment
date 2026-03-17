// Main App component - renders the header and bowler table

import React from 'react'
import './App.css'
import Header from './Header';
import PlayerList from './playerList';

function App() {
  return (
    <>
      {/* Page heading describing the app */}
      <Header/>
      {/* Table of bowlers fetched from the API */}
      <PlayerList/>
    </>
  )
};

export default App;