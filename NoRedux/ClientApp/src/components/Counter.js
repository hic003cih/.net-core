import React, { Component } from 'react';

export class Counter extends Component {
  displayName = Counter.name

    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            tempString: "temp"
        };
        this.incrementCounter = this.incrementCounter.bind(this);

        fetch('api/SampleData/Temp')
            .then(response => response.text()) //如果是回傳字串用text(),如果是object用 json()
            .then(data => {
                this.setState({ tempString: data });
            });

    }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
      <div>
        <h1>Counter</h1>

        <p>This is a simple example of a React component.</p>

            <p>Current count: <strong>{this.state.currentCount}</strong></p>

            <p>test: <strong>{this.state.tempString}</strong></p>

        <button onClick={this.incrementCounter}>Increment</button>
      </div>
    );
  }
}
