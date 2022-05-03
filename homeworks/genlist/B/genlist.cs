using System;

public class genlist<T>{
    public T[] data;
    public int size=0,capacity=8;
    public genlist(){ data = new T[capacity]; }
    public void push(T item){ //add item to list
        if(size==capacity){
            T[] newdata = new T[capacity*=2];
            for(int i=0;i<size;i++)newdata[i]=data[i];
            newdata[size]=item;
            data=newdata;
        }
        data[size]=item;
        size++;
    }
    public void remove(int i){ //want to use RemoveAt command, not sure why it doesn't work :( Doing it "manually" instead
        for(int j=i;j<size-1;j++){
            data[j] = data[j+1]; //this pushes all elements after the element we want to remove one spot back
            //effectively we will have removed the i'th element and at the same time pushed all farther elements one back
            data[j+1] = default(T);
        }
        size-=1;
    }
}