import React from 'react';
import styles from './ItemCard.module.css'
import {Item} from '../../interfaces/Item/Item'
import ItemImage from '../Images/ItemImage'

interface CardProps{
    item:Item;
}

const ItemCard: React.FC<CardProps> = ({item}) => {
  return ( 
    <div className={styles.item__list}>
      <ItemImage
        itemId={item.id}
      /> 
      <div className={styles["item__list-info"]}>
        <p className={styles["item__list-name"]}>{item.name}</p>
        <p className={styles["item__list-state"]}>{item.state}</p>
        <p className={styles["item__list-city-time"]}>{item.city} - {item.time.split("T")[0]}</p>
      </div>
      <p className={styles["item__list-price"]}>{item.price} $</p>
    </div>
  );
};

export default ItemCard;