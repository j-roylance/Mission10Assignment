// Header component - displays the page title and description

import React from 'react';
import './index.css';

const Header = () => {
  return (
    <header className="app-header">
      <h1>Bowling League Teams</h1>
      <p>Explore the most legendary bowling teams in the country!</p>
    </header>
  );
};

export default Header;