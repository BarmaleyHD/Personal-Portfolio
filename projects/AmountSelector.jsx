import React, { Component } from 'react';
import PropTypes from 'prop-types';

import { SegmentedControl } from './../../../../common/components/forms';
import './amountSelectorStyle.css';

class AmountSelector extends Component {
  constructor(props) {
    super(props);

    const { amount } = props;
    
    // Max - 40;
    this.fontSize = {
      min: 24,
      max: 35,
    };

    this.state = {
      font: this.fontSize.max,
      amount: amount || 5000,
    };
  }

  setNewAmount(value) {
    const { amount } = this.state;
    const { amountChange } = this.props;
    const bool = amount < value;
    this.setState({
      amount: value,
      // font: (bool) && this.fontSize.min,
    }, () => amountChange(value));
  }

  updateAmount(value) {
    const { amount } = this.state;
    const { amountChange } = this.props;
    const newAmount = amount + value;
    const bool = amount < newAmount;
    this.updateFont(bool);
    if (newAmount < 200) return;
    this.setState({
      amount: newAmount,
    }, () => amountChange(newAmount));
  }

  updateFont(bool) {
    const { font } = this.state;
    const newFont = (bool) ? font + 1 : font - 1;
    if (newFont < this.fontSize.min
      || newFont > this.fontSize.max) return;
    this.setState({
      // font: newFont,
      font: this.fontSize.max,
    });
  }

  render() {
    const { amount, font } = this.state;
    const { suggestions } = this.props;
    return (
      <div className="mx-auto">
        <div className="row mb-3 d-flex align-items-end">
          <button type="button" className="amount-change-btn-1 ml-1" onClick={() => this.updateAmount(-100)}>-1</button>
          <button type="button" className="amount-change-btn-2 ml-1" onClick={() => this.updateAmount(-500)}>-5</button>
          <button type="button" className="amount-change-btn-3 ml-1" onClick={() => this.updateAmount(-1000)}>-10</button>
          <div style={{ width: '100px', height: '60px', fontSize: `${font}px` }}>
            <div className="text-center text-success final-amount-wrapper">
              <i className="fa fa-dollar" />
              {amount / 100}
            </div>
          </div>
          <button type="button" className="amount-change-btn-3 mr-1" onClick={() => this.updateAmount(1000)}>+10</button>
          <button type="button" className="amount-change-btn-2 mr-1" onClick={() => this.updateAmount(500)}>+5</button>
          <button type="button" className="amount-change-btn-1 mr-1" onClick={() => this.updateAmount(100)}>+1</button>
        </div>
        <div className="row">
          <SegmentedControl
            selectedIndex={suggestions.findIndex(o => o.value === parseInt(amount, 10))}
            options={suggestions.map(o => o.label)}
            optionIcons={new Array(6).fill('dollar')}
            onChange={i => this.setNewAmount(suggestions[i].value)}
            className="mx-auto"
          />
        </div>
      </div>
    );
  }
}

AmountSelector.propTypes = {
  suggestions: PropTypes.arrayOf(PropTypes.shape()).isRequired,
  amountChange: PropTypes.func.isRequired,
  amount: PropTypes.number,
};

AmountSelector.defaultProps = {
  amount: 5000,
};

export default AmountSelector;
