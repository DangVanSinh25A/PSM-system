!(function () {
  var today = moment();

  function Calendar(selector, events) {
    this.el = document.querySelector(selector);
    this.events = events;
    this.current = moment().date(1);
    this.draw();
    var current = document.querySelector(".today");
    if (current) {
      var self = this;
      window.setTimeout(function () {
        self.openDay(current);
      }, 500);
    }
  }

  Calendar.prototype.draw = function () {
    //Create Header
    this.drawHeader();
    //Draw Day-Name
    this.drawDayName();
    //Draw Month
    this.drawMonth();
  };

  Calendar.prototype.drawHeader = function () {
    var self = this;
    if (!this.header) {
      //Create the header elements
      this.header = createElement("div", "header");
      this.header.className = "header";

      this.title = createElement("h1");

      var right = createElement("div", "right");
      right.addEventListener("click", function () {
        self.nextMonth();
      });

      var left = createElement("div", "left");
      left.addEventListener("click", function () {
        self.prevMonth();
      });

      //Append the Elements
      this.header.appendChild(this.title);
      this.header.appendChild(right);
      this.header.appendChild(left);
      this.el.appendChild(this.header);
    }

    this.title.innerHTML = this.current.format("MMMM YYYY");
  };
  Calendar.prototype.drawDayName = function () {
    if (!this.dayName) {
      //Create the dayName elements
      this.dayName = createElement("div", "dayName");
      this.dayName.className = "dayName";

      const dayNames = ["SUN", "MON", "TUE", "WED", "THU", "FRI", "SAT"];

      dayNames.forEach((day) => {
        let daySpan = createElement("b");
        daySpan.innerHTML = day;
        this.dayName.appendChild(daySpan);
      });

      //Append the Elements
      this.el.appendChild(this.dayName);
    }

    this.title.innerHTML = this.current.format("MMMM YYYY");
  };

  Calendar.prototype.drawMonth = function () {
    var self = this;

    this.events.forEach(function (ev) {
      ev.date = self.current.clone().date(Math.random() * (29 - 1) + 1);
    });

    if (this.month) {
      this.oldMonth = this.month;
      this.oldMonth.className = "month out " + (self.next ? "next" : "prev");
      this.oldMonth.addEventListener("webkitAnimationEnd", function () {
        self.oldMonth.parentNode.removeChild(self.oldMonth);
        self.month = createElement("div", "month");
        self.backFill();
        self.currentMonth();
        self.fowardFill();
        self.el.appendChild(self.month);
        window.setTimeout(function () {
          self.month.className = "month in " + (self.next ? "next" : "prev");
        }, 16);
      });
    } else {
      this.month = createElement("div", "month");
      this.el.appendChild(this.month);
      this.backFill();
      this.currentMonth();
      this.fowardFill();
      this.month.className = "month new";
    }
  };

  Calendar.prototype.backFill = function () {
    var clone = this.current.clone();
    var dayOfWeek = clone.day();

    if (!dayOfWeek) {
      return;
    }

    clone.subtract("days", dayOfWeek + 1);

    for (var i = dayOfWeek; i > 0; i--) {
      this.drawDay(clone.add("days", 1));
    }
  };

  Calendar.prototype.fowardFill = function () {
    var clone = this.current.clone().add("months", 1).subtract("days", 1);
    var dayOfWeek = clone.day();

    if (dayOfWeek === 6) {
      return;
    }

    for (var i = dayOfWeek; i < 6; i++) {
      this.drawDay(clone.add("days", 1));
    }
  };

  Calendar.prototype.currentMonth = function () {
    var clone = this.current.clone();

    while (clone.month() === this.current.month()) {
      this.drawDay(clone);
      clone.add("days", 1);
    }
  };

  Calendar.prototype.getWeek = function (day) {
    if (!this.week || day.day() === 0) {
      this.week = createElement("div", "week");
      this.month.appendChild(this.week);
    }
  };

  Calendar.prototype.drawDay = function (day) {
    var self = this;
    this.getWeek(day);

    //Outer Day
    var outer = createElement("div", this.getDayClass(day));
    outer.addEventListener("click", function () {
    
      var formattedDate = day.format("YYYY-MM-DD");
      sessionStorage.setItem("selectedDate", formattedDate);

      window.location.href = "/createForm";
    });
    // Available room
    var avaiable = createElement("div", "avaiable");
    avaiable.innerHTML = "Available: <b> 6/10 </b> rooms";

    //Day Number
    var number = createElement("div", "day-number", day.format("DD"));

    //Events
    var events = createElement("div", "day-events");
    this.drawEvents(day, events);

    outer.appendChild(avaiable);
    outer.appendChild(number);
    outer.appendChild(events);
    this.week.appendChild(outer);
  };

  Calendar.prototype.drawEvents = function (day, element) {
    var nhiSpan = document.createElement("p");
    nhiSpan.textContent = "$12";
    element.appendChild(nhiSpan);
  };

  

  Calendar.prototype.getDayClass = function (day) {
    classes = ["day"];
    if (day.month() !== this.current.month()) {
      classes.push("other");
    } else if (today.isSame(day, "day")) {
      classes.push("today");
    }
    return classes.join(" ");
  };

  Calendar.prototype.nextMonth = function () {
    this.current.add("months", 1);
    this.next = true;
    this.draw();
  };

  Calendar.prototype.prevMonth = function () {
    this.current.subtract("months", 1);
    this.next = false;
    this.draw();
  };

  window.Calendar = Calendar;

  function createElement(tagName, className, innerText) {
    var ele = document.createElement(tagName);
    if (className) {
      ele.className = className;
    }
    if (innerText) {
      ele.innderText = ele.textContent = innerText;
    }
    return ele;
  }
})();

!(function () {
  var data = [
    { eventName: "Lunch Meeting w/ Mark", calendar: "Work", color: "orange" },
    {
      eventName: "Interview - Jr. Web Developer",
      calendar: "Work",
      color: "orange",
    },
    {
      eventName: "Demo New App to the Board",
      calendar: "Work",
      color: "orange",
    },
    { eventName: "Dinner w/ Marketing", calendar: "Work", color: "orange" },

    { eventName: "Game vs Portalnd", calendar: "Sports", color: "blue" },
    { eventName: "Game vs Houston", calendar: "Sports", color: "blue" },
    { eventName: "Game vs Denver", calendar: "Sports", color: "blue" },
    { eventName: "Game vs San Degio", calendar: "Sports", color: "blue" },

    { eventName: "School Play", calendar: "Kids", color: "yellow" },
    {
      eventName: "Parent/Teacher Conference",
      calendar: "Kids",
      color: "yellow",
    },
    {
      eventName: "Pick up from Soccer Practice",
      calendar: "Kids",
      color: "yellow",
    },
    { eventName: "Ice Cream Night", calendar: "Kids", color: "yellow" },

    { eventName: "Free Tamale Night", calendar: "Other", color: "green" },
    { eventName: "Bowling Team", calendar: "Other", color: "green" },
    { eventName: "Teach Kids to Code", calendar: "Other", color: "green" },
    { eventName: "Startup Weekend", calendar: "Other", color: "green" },
  ];

  function addDate(ev) {}

  var calendar = new Calendar("#calendar", data);
})();
