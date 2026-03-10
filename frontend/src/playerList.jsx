// PlayerList - fetches bowlers from the API and displays them in a table

import React, { useState, useEffect } from 'react'

function PlayerList() {
  // State to hold the list of bowlers from the API
  const [bowlers, setBowlers] = useState([])

  // Fetch bowlers when the component mounts (Vite proxy forwards /api to backend)
  useEffect(() => {
    fetch('/api/Bowling')
      .then(res => res.ok ? res.json() : Promise.reject(res))
      .then(data => setBowlers(data))
      .catch(() => setBowlers([]))  // On error, show empty list
  }, [])

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th>Bowler Name</th>
            <th>Team Name</th>
            <th>Address</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Phone Number</th>
          </tr>
        </thead>
        <tbody>
          {/* Map each bowler to a table row */}
          {bowlers.map((b) => (
            <tr key={b.bowlerID}>
              <td>{[b.firstName, b.middleName, b.lastName].filter(Boolean).join(' ')}</td>
              <td>{b.teamName}</td>
              <td>{b.bowlerAddress}</td>
              <td>{b.bowlerCity}</td>
              <td>{b.bowlerState}</td>
              <td>{b.bowlerZip}</td>
              <td>{b.bowlerPhoneNumber}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default PlayerList