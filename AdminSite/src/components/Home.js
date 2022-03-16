import React, { useState, useEffect } from "react";

let interval;

export default function Home(props) {
  const [time, setTime] = useState(new Date().toLocaleTimeString());
  const [clickedTime, setClickedTime] = useState(0);

  useEffect(() => {
    console.log("did mount");

    interval = setInterval(
      () => setTime(new Date().toLocaleTimeString()),
      1000
    );

    return () => {
      // component will unmount
      clearInterval(interval);
    };
  }, []);

  async function clickGame() {
    await setClickedTime(clickedTime + 1);
    if (clickedTime % 15 === 0) {
      alert("FizzBuzz");
    } else if (clickedTime % 5 === 0) {
      alert("Buzz");
    } else if (clickedTime % 3 === 0) {
      alert("Fizz");
    }
  }

  return (
    <div>
      Welcome, {props.bootcamp}. It is {time}
      <button onClick={() => clickGame()}> Clicky Game</button>
    </div>
  );
}
